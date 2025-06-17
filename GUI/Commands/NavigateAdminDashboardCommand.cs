using QuizApp.Infrastructure;
using QuizApp.Stores;
using QuizApp.ViewModels;

namespace QuizApp.Commands;

public class NavigateAdminDashboardCommand : CommandBase
{
    private readonly NavigationStore _navigationStore;
    private readonly QuizManager _quizManager;

    public NavigateAdminDashboardCommand(NavigationStore navigationStore, QuizManager quizManager)
    {
        _navigationStore = navigationStore;
        _quizManager = quizManager;
    }

    public override void Execute(object parameter)
    {
        _navigationStore.CurrentViewModel =
            new AdminDashboardViewModel(App.ConnectionString, _quizManager, _navigationStore);
    }
}