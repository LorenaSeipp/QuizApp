using QuizApp.Core;
using QuizApp.Infrastructure;
using QuizApp.Stores;

namespace QuizApp.ViewModels;

public abstract class TimedQuestionViewModel : BaseViewModel
{
    protected readonly NavigationStore _navigationStore;

    private readonly Action _onQuestionHandled;
    protected readonly QuizManager _quizManager;
    protected readonly IQuizTimer _timer;

    private string _feedbackMessage;
    private bool _isFeedbackVisible;
    private bool _wasTimeUp;

    public TimedQuestionViewModel(NavigationStore navigationStore, QuizManager quizManager, Action onQuestionHandled)
    {
        _navigationStore = navigationStore;
        _quizManager = quizManager;
        _onQuestionHandled = onQuestionHandled; // Diese Action ist der Call-Back zum QuizViewModel

        _timer = quizManager.Timer; // Timer vom QuizManager holen
        _timer.TimerTick += OnTimerTick;
        _timer.TimeUp += OnTimeUp;
        _timer.Start(); // Timer starten, wenn die Frage geladen wird
    }

    public int EarnedPoints => _quizManager.PointsPerRound;
    public int TotalPoints => _quizManager.Score;

    public int RemainingSeconds => _timer.RemainingSeconds;
    public void DestructTimer()
    {
        _timer.TimerTick -= OnTimerTick;
        _timer.TimeUp -= OnTimeUp;
    }

    public bool IsFeedbackVisible
    {
        get => _isFeedbackVisible;
        set
        {
            _isFeedbackVisible = value;
            OnPropertyChanged();
        }
    }

    public string FeedbackMessage
    {
        get => _feedbackMessage;
        set
        {
            _feedbackMessage = value;
            OnPropertyChanged();
        }
    }

    public bool WasTimeUp
    {
        get => _wasTimeUp;
        set
        {
            _wasTimeUp = value;
            OnPropertyChanged();
        }
    }

    private void OnTimerTick()
    {
        OnPropertyChanged(nameof(RemainingSeconds));
    }

    protected virtual void OnTimeUp()
    {
    }

    protected async Task ShowFeedbackAndProceedAsync(string message, bool fromTimeUp)
    {
        FeedbackMessage = message;
        IsFeedbackVisible = true;
        WasTimeUp = fromTimeUp;

        DestructTimer();

        await Task.Delay(5000); // 5 Sekunden anzeigen
        IsFeedbackVisible = false;

        // Hier wird NICHT direkt navigiert, sondern die Action aufgerufen,
        _onQuestionHandled?.Invoke();
    }

    protected async void SubmitAnswerInternal(IQuestion question, object? userAnswer)
    {
        _quizManager.SubmitAnswer(question, userAnswer);
        // Now you can call OnPropertyChanged for these in the base class:
        OnPropertyChanged(nameof(EarnedPoints));
        OnPropertyChanged(nameof(TotalPoints));

        string message =
            $"Richtige Antwort: {GetCorrectAnswerForQuestion(question)} \nPunkte: {_quizManager.PointsPerRound}";
        await ShowFeedbackAndProceedAsync(message, false);
    }

    // Hilfsmethode, um die korrekte Antwort zu bekommen (kann in den spezifischen ViewModels überschrieben werden)
    protected virtual string GetCorrectAnswerForQuestion(IQuestion question)
    {
        return question switch
        {
            MultipleChoiceQuestion mcq => mcq.CorrectAnswer,
            TrueFalseQuestion tfq => tfq.IsTrue().ToString(),
            EstimateQuestion eq => eq.RightAnswer.ToString(),
            OpenQuestion oq => oq.Answer,
            _ => "Unbekannt"
        };
    }
}