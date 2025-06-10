using Meilenstein03.Commands;
using Meilenstein03.Stores;
using QuizApp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Meilenstein03.ViewModels
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
