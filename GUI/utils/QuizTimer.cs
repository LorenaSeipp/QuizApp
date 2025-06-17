using System.Diagnostics;
using System.Windows.Threading;
using QuizApp.Infrastructure;

namespace QuizApp.utils;

public class QuizTimer: IQuizTimer
{
    private readonly DispatcherTimer _timer;
    
    public event Action TimerTick;
    public event Action TimeUp;

    private readonly int _duration;
    private int _remainingSeconds;

    public int RemainingSeconds
    {
        get { return _remainingSeconds; }
    }

    public QuizTimer(int duration = 30)
    {
        _duration = duration;
        _remainingSeconds = duration;
        _timer = new DispatcherTimer();
        _timer.Interval = TimeSpan.FromSeconds(1);
        _timer.Tick += OnTick;
    }

    public void Start()
    {
        _timer.Start();
    }

    public void Stop()
    {
        _timer.Stop();
    }

    public void Reset()
    {
        _remainingSeconds = _duration;
    }

    public void OnTick(object sender, EventArgs e)
    {
        _remainingSeconds--;
        if (_remainingSeconds <= 0)
        {
            TimeUp?.Invoke();
        }
        TimerTick?.Invoke();
    }
}
