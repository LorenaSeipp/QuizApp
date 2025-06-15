using System.Windows.Threading;

namespace QuizApp.Infrastructure;

public class QuizTimer
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
        Stop();
        _remainingSeconds = _duration;
        Start();
        TimerTick?.Invoke();
    }

    public void OnTick(object sender, EventArgs e)
    {
        _remainingSeconds--;
        if (_remainingSeconds <= 0)
        {
            Stop();
            TimeUp?.Invoke();
        }
        TimerTick?.Invoke();
    }
}
