using QuizApp.Commands;
using QuizApp.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuizApp.ViewModels
{
   public class ResultViewModel : BaseViewModel
    {
        public ICommand NavigateHomeCommand{ get; }
        public ResultViewModel(NavigationStore navigationStore) 
        {
            NavigateHomeCommand = new NavigateHomeCommand(navigationStore);
        }
    }
}
