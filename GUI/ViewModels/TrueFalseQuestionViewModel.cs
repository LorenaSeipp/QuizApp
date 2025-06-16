using System.Windows.Input;
using QuizApp.Commands;
using QuizApp.Core;
using QuizApp.Infrastructure;
using QuizApp.Stores;
using QuizApp.ViewModels;

namespace QuizApp.GUI.ViewModels
{
    public class TrueFalseQuestionViewModel : TimedQuestionViewModel
    {
        private readonly NavigationStore _navigationStore;
        private readonly TrueFalseQuestion _question;
        private readonly QuizManager _quizManager;
        private int _earnedPoints;
        private bool? _userAnswer;
        public string FeedbackMessage = "";

        public TrueFalseQuestionViewModel(TrueFalseQuestion question,
            NavigationStore navigationStore, QuizManager quizManager) : base(quizManager.Timer)
        {
            _question = question;
            _quizManager = quizManager;
            _navigationStore = navigationStore;

            SubmitAnswerCommand = new RelayCommand(SubmitAnswer);
        }

        public int EarnedPoints => _quizManager.PointsPerRound;

        public int TotalPoints => _quizManager.Score;

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

                    CommandManager.InvalidateRequerySuggested();
                }
            }
        }

        public ICommand SubmitAnswerCommand { get; }

        public override async void SubmitAnswer()
        {
            if (UserAnswer.HasValue) _quizManager.SubmitAnswer(_question, UserAnswer.Value);

            OnPropertyChanged(nameof(EarnedPoints));
            OnPropertyChanged(nameof(TotalPoints));
            WasTimeUp = false;
            string message = $"Richtige Antwort: {_question.TrueFalse} \nPunkte: {EarnedPoints}";
            FeedbackMessage = message;
            await ShowFeedbackAndLoadNextAsync(message, _navigationStore, _quizManager);
        }

        protected override async void OnTimeUp()
        {
            OnPropertyChanged(nameof(EarnedPoints));
            OnPropertyChanged(nameof(TotalPoints));

            WasTimeUp = true;
            string message = $"Richtige Antwort: {_question.TrueFalse} \n Zeit abgelaufen!\nPunkte: {EarnedPoints}";
            FeedbackMessage = message;
            await ShowFeedbackAndLoadNextAsync(message, _navigationStore, _quizManager);
        }
    }
}