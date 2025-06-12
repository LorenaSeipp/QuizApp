using System.Windows.Input;
using QuizApp.Commands;
using QuizApp.Infrastructure;
using QuizApp.Stores;

namespace QuizApp.ViewModels
{
    public class ResultViewModel : BaseViewModel
    {
        public ResultViewModel(QuizManager quizmanager, NavigationStore navigationStore)
        {
            NavigateHomeCommand = new NavigateHomeCommand(navigationStore);
        }

        public ICommand NavigateHomeCommand { get; }
    }
}