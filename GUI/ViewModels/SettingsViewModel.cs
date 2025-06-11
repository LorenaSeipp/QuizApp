using QuizApp.Commands;
using QuizApp.Stores;
using QuizApp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuizApp.ViewModels
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
