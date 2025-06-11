using System.Windows;
using Microsoft.Extensions.Configuration;
using QuizApp.Infrastructure;

namespace QuizApp;

public partial class App : Application
{
    public static IConfiguration Configuration { get; private set; }
    public static string ConnectionString { get; private set; }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        // 1. Konfiguration laden
        var builder = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", false, true);

        Configuration = builder.Build();
        ConnectionString = Configuration.GetConnectionString("OracleDb");

        // 2. Services erstellen
        UserService userService = new(ConnectionString);
        OracleDatabaseService dbService = new();
        dbService.InitializeDatabase();

        QuestionRepository repository = new(ConnectionString);

        // 3. Hauptfenster starten
        MainWindow mainWindow = new();
        mainWindow.Show();
    }
}