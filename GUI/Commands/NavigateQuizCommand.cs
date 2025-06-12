using System.Windows.Input;
using QuizApp.Infrastructure;
using QuizApp.Stores;
using QuizApp.ViewModels;

namespace QuizApp.Commands
{
    public class NavigateQuizCommand : ICommand
    {
        private readonly NavigationStore _navigationStore;
        private readonly QuizManager _quizManager;

        public NavigateQuizCommand(NavigationStore navigationStore, QuizManager quizManager)
        {
            _navigationStore = navigationStore;
            _quizManager = quizManager;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = new QuizViewModel(_quizManager, _navigationStore);
        }
    }
}