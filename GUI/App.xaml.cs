using System.Windows;
using Microsoft.Extensions.Configuration;
using QuizApp.Core;
using QuizApp.Infrastructure;
using QuizApp.Stores;
using QuizApp.utils;
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
        OracleDatabaseService dbService = new(ConnectionString);
        dbService.InitializeDatabase();
        UserService userService = new(ConnectionString);
        
        QuestionRepository repository = new(ConnectionString);
        //repository.AddSortQuestion(new SortQuestion("Test", (int)QuestionEnums.Difficulty.leicht, QuestionEnums.Category.FunFacts.ToString(), "1", "2", "3", "4"));

        // Admin erstellen 
        AdminCreator adminCreator = new(ConnectionString);
        //adminCreator.CreateAdmin("Admin", "admin123", "System");

        // SETUP UI
        QuizTimer quizTimer = new QuizTimer(30);
        QuizManager quizManager = new(ConnectionString, quizTimer);
        
        NavigationStore navigationStore = new NavigationStore();
        navigationStore.CurrentViewModel = new HomeViewModel(navigationStore, quizManager);
        MainWindow = new MainWindow()
        {
            DataContext = new MainViewModel(navigationStore, quizManager)
        };
        MainWindow.Show();
        base.OnStartup(e);
    }
}