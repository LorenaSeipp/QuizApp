using Oracle.ManagedDataAccess.Client;
using QuizApp.Core;

namespace QuizApp.Infrastructure;

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

        OracleCommand? cmd = conn.CreateCommand();
        cmd.CommandText = @"
                INSERT INTO USERS (NAME, ROLE, HIGHSCORE)
                VALUES (:name, :role, :highscore)";
        cmd.Parameters.Add(":name", player.Name);
        cmd.Parameters.Add(":role", "Player");
        cmd.Parameters.Add(":highscore", player.Highscore);

        cmd.ExecuteNonQuery();
    }

    public void SaveAdmin(Admin admin)
    {
        using OracleConnection conn = new(_connectionString);
        conn.Open();

        OracleCommand? cmd = conn.CreateCommand();
        cmd.CommandText = @"
                INSERT INTO USERS (NAME, ROLE)
                VALUES (:name, :role)";
        cmd.Parameters.Add(":name", admin.Name);
        cmd.Parameters.Add(":role", "Admin");

        cmd.ExecuteNonQuery();
    }

    public List<User> GetAllUsers()
    {
        List<User> users = new();

        using OracleConnection conn = new(_connectionString);
        conn.Open();

        OracleCommand? cmd = conn.CreateCommand();
        cmd.CommandText = "SELECT ID, NAME, ROLE, HIGHSCORE FROM USERS";

        using OracleDataReader? reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            string role = reader.GetString(2);

            if (role == "Player")
                users.Add(new Player
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Role = UserRole.Player,
                    Highscore = reader.GetInt32(3)
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
        using OracleConnection conn = new(_connectionString);
        conn.Open();

        OracleCommand? cmd = conn.CreateCommand();
        cmd.CommandText = "SELECT ID, NAME, ROLE, HIGHSCORE FROM USERS WHERE NAME = :name";
        cmd.Parameters.Add(":name", name);

        using OracleDataReader? reader = cmd.ExecuteReader();
        if (reader.Read())
        {
            string role = reader.GetString(2);

            if (role == "Player")
                return new Player
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Role = UserRole.Player,
                    Highscore = reader.GetInt32(3)
                };

            if (role == "Admin")
                return new Admin
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Role = UserRole.Admin
                };
        }

//TODO Exceptionhandling 
        return null;
    }
}