using System.Windows.Input;
using QuizApp.Commands;
using QuizApp.Core;
using QuizApp.Infrastructure;
using QuizApp.Stores;

namespace QuizApp.ViewModels
{
    public class TrueFalseQuestionViewModel : TimedQuestionViewModel
    {
        private readonly TrueFalseQuestion _question;
        private bool? _userAnswer;

        public TrueFalseQuestionViewModel(TrueFalseQuestion question,
            NavigationStore navigationStore, QuizManager quizManager, Action onQuestionHandled)
            : base(navigationStore, quizManager, onQuestionHandled)
        {
            _question = question;

            SubmitAnswerCommand = new RelayCommand(ExecuteSubmitAnswerCommand, () => UserAnswer.HasValue);
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
                    ((RelayCommand)SubmitAnswerCommand).RaiseCanExecuteChanged();
                }
            }
        }

        public ICommand SubmitAnswerCommand { get; }

        private void ExecuteSubmitAnswerCommand()
        {
            if (UserAnswer.HasValue) SubmitAnswerInternal(_question, UserAnswer.Value);
        }

        protected override async void OnTimeUp()
        {
            _quizManager.SubmitAnswer(_question, null, true);

            OnPropertyChanged(nameof(EarnedPoints));
            OnPropertyChanged(nameof(TotalPoints));
            WasTimeUp = true;
            string message =
                $"Richtige Antwort: {_question.TrueFalse} \n Zeit abgelaufen!\nPunkte: {_quizManager.PointsPerRound}";
            await ShowFeedbackAndProceedAsync(message, true);
        }

        protected override string GetCorrectAnswerForQuestion(IQuestion question)
        {
            if (question is TrueFalseQuestion tfq) return tfq.IsTrue().ToString();

            return base.GetCorrectAnswerForQuestion(question);
        }
    }
}