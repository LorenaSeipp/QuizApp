using System.Windows.Input;
using QuizApp.Commands;
using QuizApp.Core;
using QuizApp.Infrastructure;
using QuizApp.Stores;

namespace QuizApp.ViewModels
{
    public class OpenQuestionViewModel : TimedQuestionViewModel
    {
        private readonly OpenQuestion _question;

        private string _userAnswer;

        public OpenQuestionViewModel(
            OpenQuestion question,
            NavigationStore navigationStore,
            QuizManager quizManager,
            Action onQuestionHandled)
            : base(navigationStore, quizManager, onQuestionHandled)
        {
            _question = question;
            _userAnswer = string.Empty;

            SubmitAnswerCommand = new RelayCommand(ExecuteSubmitAnswerCommand, () => !string.IsNullOrEmpty(UserAnswer));
        }

        public ICommand SubmitAnswerCommand { get; }

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
                    ((RelayCommand)SubmitAnswerCommand).RaiseCanExecuteChanged();
                }
            }
        }

        private void ExecuteSubmitAnswerCommand()
        {
            SubmitAnswerInternal(_question, UserAnswer);
        }

        protected override async void OnTimeUp()
        {
            _quizManager.SubmitAnswer(_question, null, true);

            WasTimeUp = true;
            string message =
                $"Zeit abgelaufen!\nRichtige Antwort: {_question.Answer}\nPunkte: {_quizManager.PointsPerRound}";

            await ShowFeedbackAndProceedAsync(message, true);
        }

        protected override string GetCorrectAnswerForQuestion(IQuestion question)
        {
            if (question is OpenQuestion oq) return oq.Answer;

            return base.GetCorrectAnswerForQuestion(question);
        }
    }
}