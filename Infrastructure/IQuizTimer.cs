namespace QuizApp.Infrastructure;

public interface IQuizTimer
{
    void Start();
    void Stop();
    void Reset();
    int RemainingSeconds { get; }
    event Action TimerTick;
    event Action TimeUp;
}