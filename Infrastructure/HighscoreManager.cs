using Oracle.ManagedDataAccess.Client;

namespace QuizApp.Infrastructure;

public class HighscoreManager
{
    private readonly string _connectionString;

    public HighscoreManager(string connectionString)
    {
        _connectionString = connectionString;
    }

    public List<(string Name, int Highscore)> GetTopHighscores(int top = 5)
    {
        var result = new List<(string Name, int Highscore)>();

        using OracleConnection conn = new(_connectionString);
        conn.Open();

        using OracleCommand cmd = conn.CreateCommand();
        cmd.CommandText = @"
                SELECT U.Name, P.HighScore 
                FROM Players P
                JOIN Users U ON P.Id = U.UserId
                ORDER BY P.HighScore DESC
                FETCH FIRST :top ROWS ONLY";

        cmd.Parameters.Add(":top", top);

        using OracleDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            string name = reader.GetString(0);
            int highscore = reader.GetInt32(1);

            result.Add((name, highscore));
        }

        return result;
    }
}