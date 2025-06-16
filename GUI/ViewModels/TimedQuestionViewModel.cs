using QuizApp.Infrastructure;
using QuizApp.Stores;

namespace QuizApp.ViewModels;

public abstract class TimedQuestionViewModel : BaseViewModel
{
    protected readonly IQuizTimer _timer;

    private string _feedbackMessage;

    private bool _isFeedbackVisible;

    private bool _wasTimeUp;

    public TimedQuestionViewModel()
    {
    }

    public TimedQuestionViewModel(IQuizTimer timer)
    {
        _timer = timer;
        _timer.TimerTick += OnTimerTick;
        _timer.TimeUp += OnTimeUp;
        _timer.Start();
    }

    public int RemainingSeconds => _timer.RemainingSeconds;

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

    protected async Task ShowFeedbackAndLoadNextAsync(string message, NavigationStore navStore, QuizManager quizManager)
    {
        FeedbackMessage = message;
        IsFeedbackVisible = true;
        await Task.Delay(5000); // 5 Sekunden anzeigen
        IsFeedbackVisible = false;

        navStore.CurrentViewModel = new QuizViewModel(navStore, quizManager);
    }

    public abstract void SubmitAnswer();
}