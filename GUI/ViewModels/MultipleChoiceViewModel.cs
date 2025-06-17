using System.Windows.Input;
using QuizApp.Commands;
using QuizApp.Infrastructure;
using QuizApp.Stores;

namespace QuizApp.ViewModels;

public class MultipleChoiceQuestionViewModel : TimedQuestionViewModel
{
    private readonly NavigationStore _navigationStore;
    private readonly MultipleChoiceQuestion _question;
    private readonly QuizManager _quizManager;
    private int _earnedPoints;
    private string _selectedAnswer;

    public MultipleChoiceQuestionViewModel(
        MultipleChoiceQuestion question,
        NavigationStore navigationStore,
        QuizManager quizManager,
        Action onQuestionHandled) : base(navigationStore, quizManager, onQuestionHandled)
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

        SubmitAnswerCommand =
            new RelayCommand(SubmitAnswerInternalCommand, () => !string.IsNullOrEmpty(SelectedAnswer));
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

    /*public ICommand SubmitAnswerCommand { get; }

    public override async void SubmitAnswer()
    {
        _quizManager.SubmitAnswer(_question, SelectedAnswer);
        OnPropertyChanged(nameof(EarnedPoints));
        OnPropertyChanged(nameof(TotalPoints));
        WasTimeUp = false;
        string message = $"Richtige Antwort: {_question.CorrectAnswer} \nPunkte: {EarnedPoints}";
        FeedbackMessage = message;
        await ShowFeedbackAndLoadNextAsync(message, _navigationStore, _quizManager);
    } */

    public ICommand SubmitAnswerCommand { get; }

    private void SubmitAnswerInternalCommand()
    {
        SubmitAnswerInternal(_question, SelectedAnswer);
    }

    protected override async void OnTimeUp()
    {
        // Logik für Zeit abgelaufen, aber rufe dann die Basis-Methode zum Fortfahren auf
        _quizManager.SubmitAnswer(_question, null, true); // Sende Null-Antwort bei Zeitablauf
        // OnPropertyChanged(nameof(EarnedPoints)); // Diese sollten schon im Basis-VM aktualisiert werden
        // OnPropertyChanged(nameof(TotalPoints));   // Diese sollten schon im Basis-VM aktualisiert werden

        string message =
            $"Richtige Antwort: {_question.CorrectAnswer} \n Zeit abgelaufen!\nPunkte: {_quizManager.PointsPerRound}";
        await ShowFeedbackAndProceedAsync(message, true);
    }
}