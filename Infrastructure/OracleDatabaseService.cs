using System;
using System.IO;
using System.Text;
using Dapper;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;

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
            "OpenQuestion"
        };

        public OracleDatabaseService()
        {
            IConfigurationBuilder  builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            IConfiguration config = builder.Build();

            _connectionString = config.GetConnectionString("OracleDb");
        }
        
        public void InitializeDatabase()
        {
            if (!TableExists())
            {
                runSQLScript("init-schema.sql");
                Console.WriteLine("Database initialized successfully.");
            }
            runSQLScript("init-data.sql");
            Console.WriteLine("One or more required tables already exist. Skipping initialization.");
        }
        
        public void runSQLScript(string fileName)
        {
            
            string sqlFilePath = Path.Combine(AppContext.BaseDirectory, fileName);
            if (!File.Exists(sqlFilePath))
            {
                Console.WriteLine($"SQL file not found: {sqlFilePath}");
                return;
            }

            string sqlScript = File.ReadAllText(sqlFilePath, Encoding.UTF8);
            string[] commands = sqlScript.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            

            using OracleConnection  connection = new OracleConnection(_connectionString);
            connection.Open();

            for (int i = 0; i < commands.Length; i++)
            {
                string commandText = commands[i].Trim();
                if (commandText.Length > 0)
                {
                    OracleCommand command = new OracleCommand(commandText, connection);
                    command.ExecuteNonQuery();
                }
            }
            connection.Close();
            
        }
        
        private bool TableExists()
        {
            using OracleConnection connection = new OracleConnection(_connectionString);
            connection.Open();

            string inClause = string.Join(",", _requiredTables.Select(t => $"'{t.ToUpper()}'"));
            string sql = $"SELECT COUNT(*) FROM user_tables WHERE table_name IN ({inClause})";
            int count = connection.ExecuteScalar<int>(sql);
            return count > 0;
        }
    }
}