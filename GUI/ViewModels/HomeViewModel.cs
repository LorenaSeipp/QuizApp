using System.Windows.Input;
using QuizApp.Commands;
using QuizApp.Infrastructure;
using QuizApp.Stores;

namespace QuizApp.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private readonly NavigationStore _navigationStore;
        private readonly QuizManager _quizManager;
        public HomeViewModel(NavigationStore navigationStore, QuizManager quizManager)
        {
            _navigationStore = navigationStore;
            _quizManager = quizManager;
            NavigateSettingsCommand = new NavigateSettingsCommand(_navigationStore, _quizManager);
            NavigateUserLoginCommand = new NavigateUserLoginCommand(_navigationStore, _quizManager);
            QuitCommand = new QuitCommand();
        }

        public ICommand NavigateSettingsCommand { get; }
        public ICommand NavigateUserLoginCommand { get; }
        public ICommand QuitCommand { get; }
    }
}