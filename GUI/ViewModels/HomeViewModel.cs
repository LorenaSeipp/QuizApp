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
