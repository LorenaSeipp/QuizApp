using Meilenstein03.Commands;
using Meilenstein03.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Meilenstein03.ViewModels
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
