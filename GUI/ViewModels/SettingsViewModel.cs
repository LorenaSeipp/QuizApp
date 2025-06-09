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
    public class SettingsViewModel : BaseViewModel
    {
        public ICommand NavigateQuizCommand{ get; }
        public SettingsViewModel(NavigationStore navigationStore) 
        {
            NavigateQuizCommand = new NavigateQuizCommand(navigationStore);
        }
    }
}
