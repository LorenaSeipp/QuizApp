using QuizApp.Stores;
using QuizApp.ViewModels;
using QuizApp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Commands
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
            QuizManager quizManager = new QuizManager()
            {

            };
            _navigationStore.CurrentViewModel = new SettingsViewModel(quizManager, _navigationStore);
        }
    }
}
