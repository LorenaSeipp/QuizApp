using System.Windows.Input;
using QuizApp.Commands;
using QuizApp.Infrastructure;
using QuizApp.Stores;

namespace QuizApp.ViewModels
{
    public class ResultViewModel : BaseViewModel
    {
        private readonly QuizManager _quizManager;
        private readonly NavigationStore _navigationStore;
        public ResultViewModel(NavigationStore navigationStore, QuizManager quizManager)
        {
            _quizManager = quizManager;
            _navigationStore = navigationStore;
            NavigateHomeCommand = new NavigateHomeCommand(_navigationStore, _quizManager);
        }

        public ICommand NavigateHomeCommand { get; }
    }
}