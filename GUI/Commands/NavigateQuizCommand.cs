using Meilenstein03.Stores;
using Meilenstein03.ViewModels;
using QuizApp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meilenstein03.Commands
{
    internal class NavigateQuizCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        public NavigateQuizCommand(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }
        public override void Execute(object parameter)
        {
            QuizManager quizManager = new QuizManager()
            {

            };
            _navigationStore.CurrentViewModel = new QuizViewModel(quizManager, _navigationStore);
        }
    }
}
