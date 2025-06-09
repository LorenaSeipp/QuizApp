using Meilenstein03.Stores;
using Meilenstein03.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meilenstein03.Commands
{
    internal class NavigateSettingsCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        public NavigateSettingsCommand(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }
        public override void Execute(object parameter)
        {
            //Setup DB
            //Give DB to Settings
            _navigationStore.CurrentViewModel = new SettingsViewModel(_navigationStore);
        }
    }
}
