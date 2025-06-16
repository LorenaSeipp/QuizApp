using QuizApp.Infrastructure;
using QuizApp.Stores;

namespace QuizApp.ViewModels;

public class EndScreenViewModel : BaseViewModel
{
    private readonly NavigationStore _navigationStore;
    private readonly QuizManager _quizManager;

    public EndScreenViewModel(double finalScore, NavigationStore navigationStore, QuizManager quizManager)
    {
        _quizManager = quizManager;
        _navigationStore = navigationStore;
        FinalScore = finalScore;
    }

    public double FinalScore { get; }
}