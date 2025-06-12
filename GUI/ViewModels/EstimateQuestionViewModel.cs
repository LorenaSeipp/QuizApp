using QuizApp.Core;
using QuizApp.Infrastructure;
using QuizApp.Stores;

namespace QuizApp.ViewModels
{
    public class EstimateQuestionViewModel : QuestionViewModel
    {
        private readonly NavigationStore _navigationStore;
        private readonly EstimateQuestion _question;
        private readonly QuizManager _quizManager;

        private int? _userAnswer;

        public EstimateQuestionViewModel(EstimateQuestion question, QuizManager quizManager,
            NavigationStore navigationStore)
        {
            _question = question;
            _quizManager = quizManager;
            _navigationStore = navigationStore;
        }

        public string QuestionText => _question.Question;

        public int AllowedMargin => _question.AllowedMargin;

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
    }
}