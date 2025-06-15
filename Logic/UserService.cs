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

    public void SavePlayer(Player player)
    {
        using OracleConnection conn = new(_connectionString);
        conn.Open();

        using OracleTransaction? trans = conn.BeginTransaction();

        try
        {
            using OracleCommand? cmdUser = conn.CreateCommand();
            cmdUser.CommandText =
                @"INSERT INTO Users (Name, Passwordhash, Role) VALUES (:name, :password, 'Player') RETURNING UserId INTO :id";
            cmdUser.Parameters.Add(":name", player.Name);
            cmdUser.Parameters.Add(":password", player.Password);

            OracleParameter paramId = new(":id", OracleDbType.Int32, ParameterDirection.Output);
            cmdUser.Parameters.Add(paramId);

            cmdUser.ExecuteNonQuery();

            int newUserId = Convert.ToInt32(paramId.Value.ToString());

            using OracleCommand? cmdPlayer = conn.CreateCommand();
            cmdPlayer.CommandText =
                @"INSERT INTO Players (Id, GamesPlayed, HighScore, AverageScore, LastPlayed) VALUES (:id, 0, 0, 0, NULL)";
            cmdPlayer.Parameters.Add(":id", newUserId);

            cmdPlayer.ExecuteNonQuery();

            trans.Commit();
        }
        catch
        {
            trans.Rollback();
            throw;
        }
    }


    public List<User> GetAllUsers()
    {
        List<User> users = new();

        using OracleConnection conn = new(_connectionString);
        conn.Open();

        OracleCommand? cmd = conn.CreateCommand();
        cmd.CommandText = "SELECT USERID, NAME, ROLE FROM USERS";

        using OracleDataReader? reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            string role = reader.GetString(2);

            if (role == "Player")
                users.Add(new Player
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Role = UserRole.Player
                });
            else if (role == "Admin")
                users.Add(new Admin
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Role = UserRole.Admin
                });
        }

        return users;
    }

    public User GetUserByName(string name)
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
                {
                    // Spieler-Daten aus Players laden
                    using OracleCommand? cmd2 = conn.CreateCommand();
                    cmd2.CommandText =
                        "SELECT GamesPlayed, HighScore, AverageScore, LastPlayed FROM Players WHERE Id = :id";
                    cmd2.Parameters.Add(":id", id);
                    using OracleDataReader? reader2 = cmd2.ExecuteReader();

                    int gamesPlayed = 0, highScore = 0;
                    double averageScore = 0;
                    DateTime? lastPlayed = null;

                    if (reader2.Read())
                    {
                        gamesPlayed = reader2.IsDBNull(0) ? 0 : reader2.GetInt32(0);
                        highScore = reader2.IsDBNull(1) ? 0 : reader2.GetInt32(1);
                        averageScore = reader2.IsDBNull(2) ? 0 : reader2.GetDouble(2);
                        lastPlayed = reader2.IsDBNull(3) ? null : reader2.GetDateTime(3);
                    }

                    return new Player
                    {
                        Id = id,
                        Name = userName,
                        Password = pwHash,
                        Role = UserRole.Player,
                        GamesPlayed = gamesPlayed,
                        Highscore = highScore,
                        AverageScore = averageScore,
                        LastPlayed = lastPlayed
                    };
                }
                case "Admin":
                {
                    // Admin-Daten aus Admins laden
                    using OracleCommand? cmd2 = conn.CreateCommand();
                    cmd2.CommandText = "SELECT CreatedAt, CreatedBy, IsActive FROM Admins WHERE Id = :id";
                    cmd2.Parameters.Add(":id", id);
                    using OracleDataReader? reader2 = cmd2.ExecuteReader();

                    DateTime createdAt = DateTime.UtcNow;
                    string createdBy = "";
                    bool canDeleteUsers = false;
                    bool isActive = false;

                    if (reader2.Read())
                    {
                        createdAt = reader2.IsDBNull(0) ? DateTime.UtcNow : reader2.GetDateTime(0);
                        createdBy = reader2.IsDBNull(1) ? "" : reader2.GetString(1);
                        isActive = reader2.IsDBNull(2) ? false : reader2.GetInt32(2) == 1;
                    }

                    return new Admin
                    {
                        Id = id,
                        Name = userName,
                        Password = pwHash,
                        Role = UserRole.Admin,
                        CreatedAt = createdAt,
                        CreatedBy = createdBy,
                        IsActive = isActive
                    };
                }
            }
        }
        catch (OracleException ex)
        {
            throw new ApplicationException("Fehler beim Abrufen des Benutzers aus der Datenbank.", ex);
        }

        return null;
    }
}