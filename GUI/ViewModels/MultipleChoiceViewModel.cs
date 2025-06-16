using System.Windows.Input;
using QuizApp.Commands;
using QuizApp.Infrastructure;
using QuizApp.Stores;
using QuizApp.ViewModels;

namespace QuizApp.GUI.ViewModels;

public class MultipleChoiceQuestionViewModel : TimedQuestionViewModel
{
    private readonly NavigationStore _navigationStore;
    private readonly MultipleChoiceQuestion _question;
    private readonly QuizManager _quizManager;
    private int _earnedPoints;

    private string _selectedAnswer;
    public string FeedbackMessage = "";

    public MultipleChoiceQuestionViewModel(
        MultipleChoiceQuestion question,
        NavigationStore navigationStore,
        QuizManager quizManager) : base(quizManager.Timer)
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

    public int EarnedPoints => _quizManager.PointsPerRound;

    public int TotalPoints => _quizManager.Score;

    public string QuestionText => _question.Question;

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

    public override async void SubmitAnswer()
    {
        _quizManager.SubmitAnswer(_question, SelectedAnswer);
        OnPropertyChanged(nameof(EarnedPoints));
        OnPropertyChanged(nameof(TotalPoints));
        WasTimeUp = false;
        string message = $"Richtige Antwort: {_question.CorrectAnswer} \nPunkte: {EarnedPoints}";
        FeedbackMessage = message;
        await ShowFeedbackAndLoadNextAsync(message, _navigationStore, _quizManager);
    }

    protected override async void OnTimeUp()
    {
        OnPropertyChanged(nameof(EarnedPoints));
        OnPropertyChanged(nameof(TotalPoints));

        WasTimeUp = true;
        string message = $"Richtige Antwort: {_question.CorrectAnswer} \n Zeit abgelaufen!\nPunkte: {EarnedPoints}";
        FeedbackMessage = message;
        await ShowFeedbackAndLoadNextAsync(message, _navigationStore, _quizManager);
    }
}