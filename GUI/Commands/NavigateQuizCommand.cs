using System.Windows.Input;
using QuizApp;
using QuizApp.Infrastructure;
using QuizApp.Stores;
using QuizApp.ViewModels;

public class NavigateQuizCommand : ICommand
{
    private readonly NavigationStore _navigationStore;
    private readonly QuizManager _quizManager;

    public NavigateQuizCommand(NavigationStore navigationStore, QuizManager quizManager)
    {
        _navigationStore = navigationStore;
        _quizManager = quizManager;
    }

    public event EventHandler CanExecuteChanged;

    public bool CanExecute(object parameter)
    {
        return true;
    }

    public void Execute(object parameter)
    {
        // Quiz mit ausgewählten Einstellungen laden
        QuestionRepository repo = new(App.ConnectionString);
        _quizManager.LoadQuestions(repo, _quizManager.Category, _quizManager.Difficulty);

        // Navigation starten
        _navigationStore.CurrentViewModel = new QuizViewModel(_navigationStore, _quizManager);
    }
}