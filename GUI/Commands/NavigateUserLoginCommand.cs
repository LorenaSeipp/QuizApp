using System.Windows.Input;
using QuizApp.Stores;
using QuizApp.ViewModels;

namespace QuizApp.Commands;

public class NavigateUserLoginCommand : ICommand
{
    private readonly NavigationStore _navigationStore;

    public NavigateUserLoginCommand(NavigationStore navigationStore)
    {
        _navigationStore = navigationStore;
    }

    public event EventHandler CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }

    public bool CanExecute(object parameter)
    {
        return true;
    }

    public void Execute(object parameter)
    {
        // Setze das CurrentViewModel auf UserLoginViewModel
        _navigationStore.CurrentViewModel = new UserLoginViewModel(_navigationStore);
    }
}