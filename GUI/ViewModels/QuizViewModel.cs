using QuizApp.Commands;
using QuizApp.Stores;
using QuizApp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuizApp.ViewModels
{
    public class QuizViewModel : BaseViewModel
    {
        public ICommand NavigateResultCommand{ get; }
        public QuizViewModel(QuizManager quizManager, NavigationStore navigationStore) 
        {
            NavigateResultCommand= new NavigateResultCommand(navigationStore);
        }
    }
}
