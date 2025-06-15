using System.Windows.Input;
using QuizApp.Commands;
using QuizApp.Core;
using QuizApp.Infrastructure;
using QuizApp.Stores;
using QuizApp.ViewModels;

namespace QuizApp.GUI.ViewModels;

public class MultipleChoiceQuestionViewModel : QuestionViewModel
{
    private readonly NavigationStore _navigationStore;
    private readonly MultipleChoiceQuestion _question;
    private readonly QuizManager _quizManager;

    private string _selectedAnswer;

    public MultipleChoiceQuestionViewModel(MultipleChoiceQuestion question, NavigationStore navigationStore, QuizManager quizManager)
    {
        _question = question;
        _quizManager = quizManager;
        _navigationStore = navigationStore;

        QuestionText = question.Question;
        Answers = new List<string>
            { question.CorrectAnswer, question.FalseAnswer1, question.FalseAnswer2, question.FalseAnswer3 };
        Answers = Answers.OrderBy(_ => Guid.NewGuid()).ToList();

        SubmitAnswerCommand = new RelayCommand(SubmitAnswer, () => !string.IsNullOrEmpty(SelectedAnswer));
    }

    public string QuestionText { get; }
    public List<string> Answers { get; }

    public string SelectedAnswer
    {
        get => _selectedAnswer;
        set
        {
            _selectedAnswer = value;
            OnPropertyChanged();
            CommandManager.InvalidateRequerySuggested();
        }
    }

    public ICommand SubmitAnswerCommand { get; }

    private void SubmitAnswer()
    {
        _quizManager.SubmitAnswer(_question, SelectedAnswer);
        _navigationStore.CurrentViewModel = new QuizViewModel(_navigationStore, _quizManager);
    }
}