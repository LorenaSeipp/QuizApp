using QuizApp.Core;
using QuizApp.Infrastructure;
using QuizApp.Stores;
using QuizApp.ViewModels;

public class QuizViewModel : BaseViewModel
{
    private readonly NavigationStore _navigationStore;
    private readonly QuizManager _quizManager;

    public QuizViewModel(QuizManager quizManager, NavigationStore navigationStore)
    {
        _quizManager = quizManager;
        _navigationStore = navigationStore;

        LoadNextQuestion();
    }

    public void LoadNextQuestion()
    {
        IQuestion? nextQuestion = _quizManager.GetNextQuestion();
        if (nextQuestion == null)
        {
            // Alle Fragen beantwortet – Navigation zum Score
            _navigationStore.CurrentViewModel = new ResultViewModel(_quizManager, _navigationStore);
            return;
        }

        // Aktuelle Frage anzeigen
        QuestionViewModel questionViewModel =
            QuestionViewModelFactory.Create(nextQuestion, _quizManager, _navigationStore);
        _navigationStore.CurrentViewModel = questionViewModel;
    }
}