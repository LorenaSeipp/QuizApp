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
    public class HomeViewModel : BaseViewModel
    {
        public ICommand NavigateSettingsCommand { get; }
        public ICommand QuitCommand { get; }
        public HomeViewModel(NavigationStore navigationStore) 
        {
            NavigateSettingsCommand = new NavigateSettingsCommand(navigationStore);
            QuitCommand = new QuitCommand();
        }
    }
}
