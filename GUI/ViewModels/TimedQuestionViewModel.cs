using QuizApp.Infrastructure;
using QuizApp.Stores;

namespace QuizApp.ViewModels;

public abstract class TimedQuestionViewModel: QuestionViewModel
{
    protected readonly IQuizTimer _timer;
    
    public int RemainingSeconds => _timer.RemainingSeconds;
    
    private bool _isFeedbackVisible;
    public bool IsFeedbackVisible
    {
        get => _isFeedbackVisible;
        set
        {
            _isFeedbackVisible = value;
            OnPropertyChanged();
        }
    }

    private string _feedbackMessage;
    public string FeedbackMessage
    {
        get => _feedbackMessage;
        set
        {
            _feedbackMessage = value;
            OnPropertyChanged();
        }
    }

    private bool _wasTimeUp;
    public bool WasTimeUp
    {
        get => _wasTimeUp;
        set
        {
            _wasTimeUp = value;
            OnPropertyChanged();
        }
    }

    public TimedQuestionViewModel(IQuizTimer timer)
    {
        _timer = timer;
        _timer.TimerTick += OnTimerTick;
        _timer.TimeUp += OnTimeUp;
        _timer.Start();
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
}