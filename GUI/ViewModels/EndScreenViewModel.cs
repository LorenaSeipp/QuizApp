// QuizApp.ViewModels/EndScreenViewModel.cs

using System.Windows.Input;
using QuizApp.Commands;
using QuizApp.Infrastructure;
using QuizApp.Stores;

// Für den Player-Typ und UserRole, falls benötigt

namespace QuizApp.ViewModels;

public class EndScreenViewModel : BaseViewModel
{
    private readonly NavigationStore _navigationStore;
    private readonly QuizManager _quizManager;

    public EndScreenViewModel(NavigationStore navigationStore, QuizManager quizManager)
    {
        _navigationStore = navigationStore;
        _quizManager = quizManager;

        PlayerName = _quizManager.CurrentPlayer?.Name ?? "Gast";

        // Der Score des aktuellen Spiels ist der Score, den der QuizManager zuletzt hatte
        FinalScore = _quizManager.Score;

        // Der Highscore des Spielers aus dem QuizManager
        PlayerHighscore = _quizManager.CurrentPlayer?.Highscore ?? 0;

        NavigateHomeCommand = new NavigateHomeCommand(_navigationStore, _quizManager);
    }

    public string PlayerName { get; }
    public int FinalScore { get; }
    public int PlayerHighscore { get; } // 

    public ICommand NavigateHomeCommand { get; }
}