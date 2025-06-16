using QuizApp.Infrastructure;
using QuizApp.Stores;
using QuizApp.ViewModels;

namespace QuizApp.Commands
{
    internal class NavigateSettingsCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly QuizManager _quizManager;

        public NavigateSettingsCommand(NavigationStore navigationStore, QuizManager quizManager)
        {
            _quizManager = quizManager;
            _navigationStore = navigationStore;
        }

        public override void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = new SettingsViewModel(_navigationStore, _quizManager);
        }
    }
}