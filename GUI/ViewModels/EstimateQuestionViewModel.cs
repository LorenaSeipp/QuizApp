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
        private string? _selectedAnswer;

        private int? _userAnswer;

        public EstimateQuestionViewModel(EstimateQuestion question, NavigationStore navigationStore, QuizManager quizManager)
        {
            _question = question;
            _quizManager = quizManager;
            _navigationStore = navigationStore;
        }

        public string? SelectedAnswer
        {
            get => _selectedAnswer;
            set
            {
                _selectedAnswer = value;
                OnPropertyChanged();
            }
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

        private void SubmitAnswer()
        {
            _quizManager.SubmitAnswer(_question, SelectedAnswer ?? string.Empty);

            QuizViewModel quizViewModel = new(_navigationStore, _quizManager);
            _navigationStore.CurrentViewModel = quizViewModel;
        }

        //TODO SubmitAnswer -> Button und Logik zur Überprüfung der Antwort (Abweichung UserAntwort zu korrektem Wert berechnen
    }
}