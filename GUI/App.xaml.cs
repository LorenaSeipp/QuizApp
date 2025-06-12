using System.Windows;
using Microsoft.Extensions.Configuration;
using QuizApp.Infrastructure;
using QuizApp.Stores;
using QuizApp.ViewModels;

namespace QuizApp;

/// <summary>
///     Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public static IConfiguration Configuration { get; private set; }
    public static string ConnectionString { get; private set; }

    protected override void OnStartup(StartupEventArgs e)
    {
        // 1. Konfiguration laden
        IConfigurationBuilder builder = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", false, true);

        Configuration = builder.Build();
        ConnectionString = Configuration.GetConnectionString("OracleDb");

        // 2. Services erstellen
        UserService userService = new(ConnectionString);
        OracleDatabaseService dbService = new();
        dbService.InitializeDatabase();

        QuestionRepository repository = new(ConnectionString);

        // Admin erstellen 
        AdminCreator adminCreator = new(ConnectionString);
        adminCreator.CreateAdmin("Admin", "admin123", "System");

        // SETUP UI
        NavigationStore navigationStore = new NavigationStore();
        navigationStore.CurrentViewModel = new HomeViewModel(navigationStore);
        MainWindow = new MainWindow()
        {
            DataContext = new MainViewModel(navigationStore)
        };
        MainWindow.Show();
        base.OnStartup(e);
    }
}