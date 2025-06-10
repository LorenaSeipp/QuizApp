using Meilenstein03.Commands;
using Meilenstein03.Stores;
using QuizApp.Infrastructure;
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
        private QuizManager QuizManager { get; }
        //public Difficulty => QuizManager.Difficulty;
        //public NumberOfQuestions => QuizManager.NumberOfQuestions;
        public SettingsViewModel(QuizManager quizManager, NavigationStore navigationStore) 
        {
            NavigateQuizCommand = new NavigateQuizCommand(navigationStore);
            QuizManager = quizManager;
        }
    }
}
