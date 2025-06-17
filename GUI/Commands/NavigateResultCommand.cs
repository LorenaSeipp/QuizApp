using QuizApp.Infrastructure;
using QuizApp.Stores;
using QuizApp.ViewModels;

namespace QuizApp.Commands
{
    internal class NavigateResultCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly QuizManager _quizManager;

        public NavigateResultCommand(NavigationStore navigationStore, QuizManager quizManager)
        {
            _navigationStore = navigationStore;
            _navigationStore = navigationStore;
        }

        public override void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = new EndScreenViewModel(_navigationStore, _quizManager);
        }
    }
}