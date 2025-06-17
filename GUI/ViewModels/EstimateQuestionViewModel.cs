using System.Windows.Input;
using QuizApp.Commands;
using QuizApp.Core;
using QuizApp.Infrastructure;
using QuizApp.Stores;

namespace QuizApp.ViewModels
{
    public class EstimateQuestionViewModel : TimedQuestionViewModel
    {
        private readonly EstimateQuestion _question;

        private int? _userAnswer;

        public EstimateQuestionViewModel(
            EstimateQuestion question,
            NavigationStore navigationStore,
            QuizManager quizManager,
            Action onQuestionHandled)
            : base(navigationStore, quizManager, onQuestionHandled) // Pass all parameters to the base constructor
        {
            _question = question;
            SubmitAnswerCommand = new RelayCommand(ExecuteSubmitAnswerCommand, () => UserAnswer.HasValue);
        }

        public ICommand SubmitAnswerCommand { get; }

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
                    ((RelayCommand)SubmitAnswerCommand).RaiseCanExecuteChanged();
                }
            }
        }

        private void ExecuteSubmitAnswerCommand()
        {
            // Ensure UserAnswer has a value before attempting to submit
            if (UserAnswer.HasValue) SubmitAnswerInternal(_question, UserAnswer.Value);
        }

        protected override async void OnTimeUp()
        {
            _quizManager.SubmitAnswer(_question, null, wasTimeUp: true);

            WasTimeUp = true;

            string message =
                $"Zeit abgelaufen!\nRichtige Antwort: {_question.RightAnswer}\nPunkte: {_quizManager.PointsPerRound}";

            await ShowFeedbackAndProceedAsync(message, true);
        }

        protected override string GetCorrectAnswerForQuestion(IQuestion question)
        {
            // Safely cast the IQuestion to EstimateQuestion to access its specific properties
            if (question is EstimateQuestion eq) return eq.RightAnswer.ToString();

            // Fallback to the base class's implementation if the question type is not as expected
            return base.GetCorrectAnswerForQuestion(question);
        }
    }
}