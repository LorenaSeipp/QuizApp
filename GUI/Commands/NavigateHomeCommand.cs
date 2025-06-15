using QuizApp.Stores;
using QuizApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizApp.Infrastructure;

namespace QuizApp.Commands
{
    internal class NavigateHomeCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly QuizManager _quizManager;
        public NavigateHomeCommand(NavigationStore navigationStore, QuizManager quizManager)
        {
            _quizManager = quizManager;
            _navigationStore = navigationStore;
        }
        public override void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = new HomeViewModel(_navigationStore, _quizManager);
        }
    }
}
