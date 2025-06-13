using System.Windows.Input;
using QuizApp.Commands;
using QuizApp.Core;
using QuizApp.Infrastructure;
using QuizApp.Stores;
using QuizApp.ViewModels;

namespace QuizApp.GUI.ViewModels
{
    public class TrueFalseQuestionViewModel : QuestionViewModel
    {
        private readonly NavigationStore _navigationStore;
        private readonly TrueFalseQuestion _question;
        private readonly QuizManager _quizManager;
        private bool? _userAnswer;

        public TrueFalseQuestionViewModel(TrueFalseQuestion question,
            NavigationStore navigationStore, QuizManager quizManager)
        {
            _question = question;
            _quizManager = quizManager;
            _navigationStore = navigationStore;

            SubmitAnswerCommand = new RelayCommand(SubmitAnswer, () => UserAnswer.HasValue);
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

                    CommandManager.InvalidateRequerySuggested();
                }
            }
        }

        public ICommand SubmitAnswerCommand { get; }

        private void SubmitAnswer()
        {
            if (UserAnswer.HasValue) _quizManager.SubmitAnswer(_question, UserAnswer.Value);

            QuizViewModel quizViewModel = new(_navigationStore, _quizManager);
            _navigationStore.CurrentViewModel = quizViewModel;
        }

        //TODO SubmitAnswer -> Button und Logik zur Überprüfung der Antwort 
    }
}