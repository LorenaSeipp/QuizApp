using QuizApp.Infrastructure;
using QuizApp.Stores;
using QuizApp.ViewModels;

namespace QuizApp.Commands
{
    internal class NavigateHomeCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly QuizManager _quizManager;

        public NavigateHomeCommand(NavigationStore navigationStore, QuizManager quizManager)
        {
            _quizManager = quizManager;
            _navigationStore = navigationStore;
        }

        public override void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = new HomeViewModel(_navigationStore, _quizManager);
        }
    }
}