using QuizApp.Core;
using QuizApp.Infrastructure;
using QuizApp.Stores;
using QuizApp.ViewModels;

public class QuizViewModel : BaseViewModel
{
    private readonly NavigationStore _navigationStore;
    private readonly QuizManager _quizManager;

    private QuestionViewModel? _currentQuestion;

    public QuizViewModel(QuizManager quizManager, NavigationStore navigationStore)
    {
        _quizManager = quizManager;
        _navigationStore = navigationStore;

        LoadNextQuestion();
    }

    public QuestionViewModel? CurrentQuestion
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
            _navigationStore.CurrentViewModel = new ResultViewModel(_quizManager, _navigationStore);
            return;
        }

        CurrentQuestion = QuestionViewModelFactory.Create(nextQuestion, _quizManager, _navigationStore);
    }
}