using QuizApp.Core;
using QuizApp.Infrastructure;
using QuizApp.Stores;

namespace QuizApp.ViewModels
{
    public class TrueFalseQuestionViewModel : QuestionViewModel
    {
        private readonly NavigationStore _navigationStore;
        private readonly TrueFalseQuestion _question;
        private readonly QuizManager _quizManager;

        private bool? _userAnswer;

        public TrueFalseQuestionViewModel(TrueFalseQuestion question, QuizManager quizManager,
            NavigationStore navigationStore)
        {
            _question = question;
            _quizManager = quizManager;
            _navigationStore = navigationStore;
        }

        public string QuestionText => _question.Question;

        public bool? UserAnswer
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

        // Hier ggf. Commands und Logik zum Beantworten hinzufügen
    }
}