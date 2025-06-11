using System.Windows.Input;
using QuizApp.Commands;
using QuizApp.Stores;

namespace QuizApp.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public HomeViewModel(NavigationStore navigationStore)
        {
            NavigateSettingsCommand = new NavigateSettingsCommand(navigationStore);
            NavigateUserLoginCommand = new NavigateUserLoginCommand(navigationStore);
            QuitCommand = new QuitCommand();
        }

        public ICommand NavigateSettingsCommand { get; }
        public ICommand NavigateUserLoginCommand { get; }
        public ICommand QuitCommand { get; }
    }
}