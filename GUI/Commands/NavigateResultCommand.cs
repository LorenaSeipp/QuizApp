using QuizApp.Infrastructure;
using QuizApp.Stores;
using QuizApp.ViewModels;

namespace QuizApp.Commands
{
    internal class NavigateResultCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly QuizManager _quizManager;

        public NavigateResultCommand(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }

        public override void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = new ResultViewModel(_quizManager, _navigationStore);
        }
    }
}