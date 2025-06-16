using QuizApp.Infrastructure;
using QuizApp.Stores;

namespace QuizApp.ViewModels;

public class EndScreenViewModel : QuestionViewModel
{
    private readonly NavigationStore _navigationStore;
    private readonly QuizManager _quizManager;
    public double FinalScore { get; }

    public EndScreenViewModel(double finalScore, NavigationStore navigationStore, QuizManager quizManager) 
    {
        _quizManager = quizManager;
        _navigationStore = navigationStore;
        FinalScore = finalScore;
    }
}