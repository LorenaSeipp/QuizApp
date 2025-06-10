using QuizApp;
using QuizApp.Stores;
using QuizApp.ViewModels;
using System.IO;
using System.Windows;
using Microsoft.Extensions.Configuration;
using QuizApp.Core;
using QuizApp.Infrastructure;

namespace QuizApp;

/// <summary>
///     Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        IConfigurationBuilder  builder = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        IConfiguration config = builder.Build();

        string connectionString = config.GetConnectionString("OracleDb");
        
        var dbService = new OracleDatabaseService();
        dbService.InitializeDatabase();
        
        QuestionRepository repository = new QuestionRepository(connectionString);
        List<SortQuestion> questions = repository.GetAllSortQuestions();

        foreach (SortQuestion question in questions)
        {
            Console.WriteLine(question.ToString());
        }


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