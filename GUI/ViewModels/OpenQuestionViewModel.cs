using System.Windows.Input;
using QuizApp.Commands;
using QuizApp.Core;
using QuizApp.Infrastructure;
using QuizApp.Stores;
using QuizApp.ViewModels;

namespace QuizApp.GUI.ViewModels
{
    public class OpenQuestionViewModel : TimedQuestionViewModel
    {
        private readonly NavigationStore _navigationStore;
        private readonly OpenQuestion _question;
        private readonly QuizManager _quizManager;

        private int _earnedPoints;

        private string _userAnswer;
        public string FeedbackMessage = "";

        public OpenQuestionViewModel(OpenQuestion question, NavigationStore navigationStore, QuizManager quizManager) :
            base(quizManager.Timer)
        {
            _question = question;
            _quizManager = quizManager;
            _navigationStore = navigationStore;

            SubmitAnswerCommand = new RelayCommand(SubmitAnswer);
        }

        public int EarnedPoints => _quizManager.PointsPerRound;

        public int TotalPoints => _quizManager.Score;

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

        public ICommand SubmitAnswerCommand { get; }

        public override async void SubmitAnswer()
        {
            _quizManager.SubmitAnswer(_question, UserAnswer);
            OnPropertyChanged(nameof(EarnedPoints));
            OnPropertyChanged(nameof(TotalPoints));
            WasTimeUp = false;
            string message = $"Richtige Antwort: {_question.Answer} \n Punkte: {EarnedPoints}";
            FeedbackMessage = message;
            await ShowFeedbackAndLoadNextAsync(message, _navigationStore, _quizManager);
        }


        protected override async void OnTimeUp()
        {
            _quizManager.SubmitAnswer(_question, null, true);

            OnPropertyChanged(nameof(EarnedPoints));
            OnPropertyChanged(nameof(TotalPoints));

            WasTimeUp = true;
            string message = $"Zeit abgelaufen!\nRichtige Antwort: {_question.Answer}\nPunkte: {EarnedPoints}";
            FeedbackMessage = message;
            await ShowFeedbackAndLoadNextAsync(message, _navigationStore, _quizManager);
        }
    }
}