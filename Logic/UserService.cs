using System.Data;
using Oracle.ManagedDataAccess.Client;
using QuizApp.Core.Models;

namespace QuizApp.Logic;

public class UserService
{
    private readonly string _connectionString;

    public UserService(string connectionString)
    {
        _connectionString = connectionString;
    }

    /// <summary>
    ///     Speichert einen neuen Spieler (User + Player) in der Datenbank.
    /// </summary>
    public void SavePlayer(Player player)
    {
        using OracleConnection conn = new(_connectionString);
        conn.Open();

        using OracleTransaction trans = conn.BeginTransaction();
        try
        {
            // User einfügen
            using OracleCommand cmdUser = conn.CreateCommand();
            cmdUser.CommandText =
                @"INSERT INTO Users (Name, Passwordhash, Role) VALUES (:name, :password, 'Player') RETURNING UserId INTO :id";
            cmdUser.Parameters.Add(":name", player.Name);
            cmdUser.Parameters.Add(":password", player.Password);

            OracleParameter paramId = new(":id", OracleDbType.Int32, ParameterDirection.Output);
            cmdUser.Parameters.Add(paramId);
            cmdUser.ExecuteNonQuery();

            int newUserId = Convert.ToInt32(paramId.Value.ToString());

            // Player-Datensatz einfügen
            using OracleCommand cmdPlayer = conn.CreateCommand();
            cmdPlayer.CommandText =
                @"INSERT INTO Players (Id, GamesPlayed, HighScore, AverageScore, LastPlayed) VALUES (:id, 0, 0, 0, NULL)";
            cmdPlayer.Parameters.Add(":id", newUserId);
            cmdPlayer.ExecuteNonQuery();

            trans.Commit();
        }
        catch (Exception)
        {
            trans.Rollback();
            throw new ApplicationException("Fehler beim Speichern des Spielers.");
        }
    }

    /// <summary>
    ///     Gibt alle Benutzer (Player & Admin) zurück.
    /// </summary>
    public List<User> GetAllUsers()
    {
        List<User> users = new();
        using OracleConnection conn = new(_connectionString);
        conn.Open();

        using OracleCommand cmd = conn.CreateCommand();
        cmd.CommandText = "SELECT USERID, NAME, ROLE FROM USERS";

        using OracleDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            string role = reader.GetString(2);
            if (role == "Player")
            {
                users.Add(new Player
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Role = UserRole.Player
                });
            }
            else if (role == "Admin")
            {
                users.Add(new Admin
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Role = UserRole.Admin
                });
            }
        }

        return users;
    }

    /// <summary>
    ///     Sucht Benutzer anhand des Namens, inkl. spezieller Behandlung für Admin/Player.
    /// </summary>
    public User? GetUserByName(string name)
    {
        try
        {
            using OracleConnection conn = new(_connectionString);
            conn.Open();

            using OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT UserId, Name, Passwordhash, Role FROM Users WHERE Name = :name";
            cmd.Parameters.Add(":name", name);

            using OracleDataReader reader = cmd.ExecuteReader();
            if (!reader.Read()) return null;

            int id = reader.GetInt32(0);
            string userName = reader.GetString(1);
            string pwHash = reader.GetString(2);
            string role = reader.GetString(3);

            switch (role)
            {
                case "Player":
                    using (OracleCommand cmd2 = conn.CreateCommand())
                    {
                        cmd2.CommandText =
                            "SELECT GamesPlayed, HighScore, AverageScore, LastPlayed FROM Players WHERE Id = :id";
                        cmd2.Parameters.Add(":id", id);

                        using OracleDataReader reader2 = cmd2.ExecuteReader();
                        if (reader2.Read())
                            return new Player
                            {
                                Id = id,
                                Name = userName,
                                Password = pwHash,
                                Role = UserRole.Player,
                                GamesPlayed = reader2.IsDBNull(0) ? 0 : reader2.GetInt32(0),
                                Highscore = reader2.IsDBNull(1) ? 0 : reader2.GetInt32(1),
                                AverageScore = reader2.IsDBNull(2) ? 0 : reader2.GetDouble(2),
                                LastPlayed = reader2.IsDBNull(3) ? null : reader2.GetDateTime(3)
                            };
                    }

                    break;

                case "Admin":
                    using (OracleCommand cmd2 = conn.CreateCommand())
                    {
                        cmd2.CommandText = "SELECT CreatedAt, CreatedBy, IsActive FROM Admins WHERE Id = :id";
                        cmd2.Parameters.Add(":id", id);

                        using OracleDataReader reader2 = cmd2.ExecuteReader();
                        if (reader2.Read())
                            return new Admin
                            {
                                Id = id,
                                Name = userName,
                                Password = pwHash,
                                Role = UserRole.Admin,
                                CreatedAt = reader2.IsDBNull(0) ? DateTime.UtcNow : reader2.GetDateTime(0),
                                CreatedBy = reader2.IsDBNull(1) ? "" : reader2.GetString(1),
                                IsActive = reader2.IsDBNull(2) ? false : reader2.GetInt32(2) == 1
                            };
                    }

                    break;
            }

            return null;
        }
        catch (OracleException ex)
        {
            throw new ApplicationException("Fehler beim Abrufen des Benutzers aus der Datenbank.", ex);
        }
    }

    /// <summary>
    ///     Aktualisiert die Spielerstatistiken nach einem Spiel.
    /// </summary>
    public void UpdatePlayerStats(int playerId, int newScore)
    {
        using OracleConnection conn = new(_connectionString);
        conn.Open();
        using OracleTransaction trans = conn.BeginTransaction();

        try
        {
            int gamesPlayed = 0;
            int highScore = 0;
            double avgScore = 0;

            using (OracleCommand selectCmd = conn.CreateCommand())
            {
                selectCmd.CommandText = @"SELECT GamesPlayed, HighScore, AverageScore FROM Players WHERE Id = :id";
                selectCmd.Parameters.Add(":id", playerId);

                using OracleDataReader reader = selectCmd.ExecuteReader();
                if (reader.Read())
                {
                    gamesPlayed = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                    highScore = reader.IsDBNull(1) ? 0 : reader.GetInt32(1);
                    avgScore = reader.IsDBNull(2) ? 0 : reader.GetDouble(2);
                }
            }

            gamesPlayed++;
            highScore = Math.Max(highScore, newScore);
            avgScore = (avgScore * (gamesPlayed - 1) + newScore) / gamesPlayed;

            using (OracleCommand updateCmd = conn.CreateCommand())
            {
                updateCmd.CommandText = @"
                    UPDATE Players 
                    SET GamesPlayed = :gamesPlayed,
                        HighScore = :highScore,
                        AverageScore = :averageScore,
                        LastPlayed = :lastPlayed
                    WHERE Id = :id";

                updateCmd.Parameters.Add(":gamesPlayed", gamesPlayed);
                updateCmd.Parameters.Add(":highScore", highScore);
                updateCmd.Parameters.Add(":averageScore", avgScore);
                updateCmd.Parameters.Add(":lastPlayed", DateTime.UtcNow);
                updateCmd.Parameters.Add(":id", playerId);

                updateCmd.ExecuteNonQuery();
            }

            trans.Commit();
        }
        catch
        {
            trans.Rollback();
            throw new ApplicationException("Fehler beim Aktualisieren der Spielerstatistiken.");
        }
    }

    /// <summary>
    ///     Gibt den Highscore eines Spielers zurück.
    /// </summary>
    public int GetPlayerHighScore(int playerId)
    {
        try
        {
            using OracleConnection conn = new(_connectionString);
            conn.Open();

            using OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = @"SELECT HighScore FROM Players WHERE Id = :id";
            cmd.Parameters.Add(":id", playerId);

            using OracleDataReader reader = cmd.ExecuteReader();
            if (reader.Read()) return reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Fehler beim Abrufen des Highscores.", ex);
        }

        return 0;
    }

    /// <summary>
    ///     Gibt die vollständigen Statistiken eines Spielers zurück.
    /// </summary>
    public PlayerStats? GetPlayerStats(int playerId)
    {
        try
        {
            using OracleConnection conn = new(_connectionString);
            conn.Open();

            using OracleCommand cmd = conn.CreateCommand();
            cmd.CommandText = @"SELECT GamesPlayed, HighScore, AverageScore, LastPlayed FROM Players WHERE Id = :id";
            cmd.Parameters.Add(":id", playerId);

            using OracleDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
                return new PlayerStats
                {
                    GamesPlayed = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                    HighScore = reader.IsDBNull(1) ? 0 : reader.GetInt32(1),
                    AverageScore = reader.IsDBNull(2) ? 0 : reader.GetDouble(2),
                    LastPlayed = reader.IsDBNull(3) ? null : reader.GetDateTime(3)
                };

            return null;
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Fehler beim Abrufen der Spielerstatistiken.", ex);
        }
    }
}