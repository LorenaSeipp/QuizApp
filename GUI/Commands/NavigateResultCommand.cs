using Meilenstein03.Stores;
using Meilenstein03.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meilenstein03.Commands
{
    internal class NavigateResultCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        public NavigateResultCommand(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }
        public override void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = new ResultViewModel(_navigationStore);
        }
    }
}
