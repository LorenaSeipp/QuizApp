using System.Windows.Input;
using QuizApp.Commands;
using QuizApp.Core;
using QuizApp.Infrastructure;
using QuizApp.Stores;
using QuizApp.ViewModels;

namespace QuizApp.GUI.ViewModels
{
    public class EstimateQuestionViewModel : QuestionViewModel
    {
        private readonly NavigationStore _navigationStore;
        private readonly EstimateQuestion _question;
        private readonly QuizManager _quizManager;

        private int? _userAnswer;
        
        public ICommand SubmitCommand => new RelayCommand(SubmitAnswer, () => UserAnswer.HasValue);

        public EstimateQuestionViewModel(EstimateQuestion question, NavigationStore navigationStore, QuizManager quizManager)
        {
            _question = question;
            _quizManager = quizManager;
            _navigationStore = navigationStore;
        }



        public string QuestionText => _question.Question;

        public int? UserAnswer
        {
            get => _userAnswer;
            set
            {
                if (_userAnswer != value)
                {
                    _userAnswer = value;
                    OnPropertyChanged();
                }
            }
        }

        private void SubmitAnswer()
        {
            if (UserAnswer == null)
                return; // oder Fehler anzeigen

            _quizManager.SubmitAnswer(_question, UserAnswer.Value);

            QuizViewModel quizViewModel = new(_navigationStore, _quizManager);
            _navigationStore.CurrentViewModel = quizViewModel;
        }
        
     //TODO SubmitAnswer -> Button und Logik zur Überprüfung der Antwort (Abweichung UserAntwort zu korrektem Wert berechnen
    }
}