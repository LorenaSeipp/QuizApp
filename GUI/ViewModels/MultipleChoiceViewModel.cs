using System.Windows.Input;
using QuizApp.Commands;
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

    public MultipleChoiceQuestionViewModel(
        MultipleChoiceQuestion question,
        NavigationStore navigationStore,
        QuizManager quizManager)
    {
        _question = question;
        _quizManager = quizManager;
        _navigationStore = navigationStore;

        // Alle Antworten mischen
        Answers = new List<string>
        {
            _question.CorrectAnswer,
            _question.FalseAnswer1,
            _question.FalseAnswer2,
            _question.FalseAnswer3
        }.OrderBy(_ => Guid.NewGuid()).ToList();

        SubmitAnswerCommand = new RelayCommand(SubmitAnswer, () => !string.IsNullOrEmpty(SelectedAnswer));
    }

    public List<string> Answers { get; }

    public string SelectedAnswer
    {
        get => _selectedAnswer;
        set
        {
            _selectedAnswer = value;
            OnPropertyChanged();
            ((RelayCommand)SubmitAnswerCommand).RaiseCanExecuteChanged();
        }
    }

    public ICommand SubmitAnswerCommand { get; }

    public override void SubmitAnswer()
    {
        _quizManager.SubmitAnswer(_question, SelectedAnswer);
        _navigationStore.CurrentViewModel = new QuizViewModel(_navigationStore, _quizManager);
    }
}