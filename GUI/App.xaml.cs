using Meilenstein03;
using Meilenstein03.Stores;
using Meilenstein03.ViewModels;
using System.Windows;

namespace QuizApp;

/// <summary>
///     Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
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