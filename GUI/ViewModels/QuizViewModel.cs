using QuizApp.Core;
using QuizApp.Infrastructure;
using QuizApp.Stores;
using QuizApp.ViewModels;

public class QuizViewModel : BaseViewModel
{
    private readonly NavigationStore _navigationStore;
    private readonly QuizManager _quizManager;

    private TimedQuestionViewModel? _currentQuestion;

    public QuizViewModel(NavigationStore navigationStore, QuizManager quizManager)
    {
        _quizManager = quizManager;
        _navigationStore = navigationStore;

        LoadNextQuestion();
    }

    public TimedQuestionViewModel? CurrentQuestion
    {
        get => _currentQuestion;
        set
        {
            _currentQuestion = value;
            OnPropertyChanged();
        }
    }

    public void LoadNextQuestion()
    {
        IQuestion? nextQuestion = _quizManager.GetNextQuestion();

        if (nextQuestion == null)
        {
            _navigationStore.CurrentViewModel = new EndScreenViewModel(_navigationStore, _quizManager);
            return;
        }

        CurrentQuestion = QuestionViewModelFactory.Create(nextQuestion, _navigationStore, _quizManager);
    }
}