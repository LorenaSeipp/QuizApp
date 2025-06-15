using System.Windows.Input;
using QuizApp.Commands;
using QuizApp.Core;
using QuizApp.Infrastructure;
using QuizApp.Stores;
using QuizApp.ViewModels;

namespace QuizApp.GUI.ViewModels
{
    public class EstimateQuestionViewModel : TimedQuestionViewModel
    {
        private readonly NavigationStore _navigationStore;
        private readonly EstimateQuestion _question;
        private readonly QuizManager _quizManager;
        
        private int? _userAnswer;
        
        private int _earnedPoints;
        public int EarnedPoints
        {
            get => _earnedPoints;
            set
            {
                if (_earnedPoints != value)
                {
                    _earnedPoints = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(TotalPoints));
                }
            }
        }

        public int TotalPoints => _quizManager.Score;
        
        public ICommand SubmitCommand => new RelayCommand(SubmitAnswer, () => UserAnswer.HasValue);

        public EstimateQuestionViewModel(EstimateQuestion question, NavigationStore navigationStore, QuizManager quizManager)
        :base(quizManager.Timer)
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

        private async void SubmitAnswer()
        {
            if (UserAnswer == null)
                return; // oder Fehler anzeigen

            _quizManager.SubmitAnswer(_question, UserAnswer.Value);
            EarnedPoints = _question.CalculatePoints(UserAnswer.Value);
            OnPropertyChanged(nameof(TotalPoints));
            WasTimeUp = false;

            string message = $"Richtige Antwort: {_question.RightAnswer}\nPunkte: {EarnedPoints}";
            await ShowFeedbackAndLoadNextAsync(message, _navigationStore, _quizManager);
        }
        

        protected override async void OnTimeUp()
        {
            _quizManager.SubmitAnswer(_question, null, wasTimeUp: true);

            EarnedPoints = 0;
            OnPropertyChanged(nameof(TotalPoints));
            
            WasTimeUp = true;
            string message = $"Zeit abgelaufen!\nRichtige Antwort: {_question.RightAnswer}\nPunkte: {EarnedPoints}";
            await ShowFeedbackAndLoadNextAsync(message, _navigationStore, _quizManager);
        }
    }
}