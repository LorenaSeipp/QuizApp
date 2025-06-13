using QuizApp.Core;
using QuizApp.Infrastructure;
using QuizApp.Stores;
using QuizApp.ViewModels;

namespace QuizApp.GUI.ViewModels
{
    public class OpenQuestionViewModel : QuestionViewModel
    {
        private readonly NavigationStore _navigationStore;
        private readonly OpenQuestion _question;
        private readonly QuizManager _quizManager;

        private string _userAnswer;

        public OpenQuestionViewModel(OpenQuestion question, NavigationStore navigationStore, QuizManager quizManager)
        {
            _question = question;
            _quizManager = quizManager;
            _navigationStore = navigationStore;
        }

        public string QuestionText => _question.Question;

        public string UserAnswer
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
        //TODO SubmitAnswer -> Button und Logik zur Überprüfung der Antwort 
    }
}