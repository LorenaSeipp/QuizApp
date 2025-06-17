using System.Text;
using Dapper;
using Oracle.ManagedDataAccess.Client;
using QuizApp.Core.Exceptions;

namespace QuizApp.Infrastructure
{
    public class OracleDatabaseService
    {
        private readonly string _connectionString;

        private readonly string[] _requiredTables = new[]
        {
            "SortQuestion",
            "MultipleChoiceQuestion",
            "EstimateQuestion",
            "TrueFalseQuestion",
            "OpenQuestion",
            "Admins",
            "Players",
            "Users"
        };

        public OracleDatabaseService(string _connectionString)
        {
            this._connectionString = _connectionString;
        }

        public void InitializeDatabase()
        {
            if (!TableExists())
            {
                try
                {
                    runSQLScript("init-schema.sql");
                    Console.WriteLine("Database initialized successfully.");
                }
                catch (FileNotFoundException ex)
                {
                    throw new DatabaseInitializationException(
                        "SQL-Skript zum Initialisieren der Datenbank nicht gefunden.", ex);
                }
                catch (Exception ex)
                {
                    throw new DatabaseInitializationException("Fehler beim Initialisieren der Datenbank.", ex);
                }
            }

            try
            {
                //DIESE ZEILE DARF NUR BEIM ERSTEN BEFÜLLEN DER DB AUSGEFÜHRT WERDEN
                runSQLScript("init-data.sql");
                Console.WriteLine("Data loaded successfully.");
            }
            catch (FileNotFoundException ex)
            {
                throw new DataLoadingException("SQL-Skript zum Befüllen der Datenbank nicht gefunden.", ex);
            }
            catch (Exception ex)
            {
                throw new DataLoadingException("Fehler beim Befüllen der Tabellen mit Daten.", ex);
            }
        }

        public void runSQLScript(string fileName)
        {
            string sqlFilePath = Path.Combine(AppContext.BaseDirectory, fileName);
            if (!File.Exists(sqlFilePath))
            {
                throw new FileNotFoundException($"SQL File {fileName} not found in the path: {sqlFilePath}");
            }

            string sqlScript = File.ReadAllText(sqlFilePath, Encoding.UTF8);
            string[] commands = sqlScript.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            using OracleConnection connection = new OracleConnection(_connectionString);
            connection.Open();

            for (int i = 0; i < commands.Length; i++)
            {
                string commandText = commands[i].Trim();
                if (commandText.EndsWith(";"))
                {
                    commandText = commandText.Substring(0, commandText.Length - 1);
                }

                if (commandText.Length > 0)
                {
                    try
                    {
                        OracleCommand command = new OracleCommand(commandText, connection);
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new SqlExecutionException(commandText, ex);
                    }
                }
            }

            connection.Close();
        }

        private bool TableExists()
        {
            using OracleConnection connection = new OracleConnection(_connectionString);
            connection.Open();

            string inClause = string.Join(",", _requiredTables.Select(t => $"'{t.ToUpper()}'"));
            string sql = $"SELECT table_name FROM user_tables WHERE table_name IN ({inClause})";
            List<string> existingTables = connection.Query<string>(sql).ToList();

            return _requiredTables.All(table => existingTables.Contains(table.ToUpper()));
        }
    }
}