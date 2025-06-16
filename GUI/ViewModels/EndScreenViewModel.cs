using QuizApp.Infrastructure;
using QuizApp.Stores;

namespace QuizApp.ViewModels;

public class EndScreenViewModel : BaseViewModel
{
    private readonly NavigationStore _navigationStore;
    private readonly QuizManager _quizManager;

    public EndScreenViewModel(NavigationStore navigationStore, QuizManager quizManager)
    {
        _quizManager = quizManager;
        _navigationStore = navigationStore;
        FinalScore = _quizManager.Score;
    }

    private int FinalScore { get; }
}