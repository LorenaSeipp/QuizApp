using System.Windows.Input;
using QuizApp.Commands;
using QuizApp.Infrastructure;
using QuizApp.Stores;

namespace QuizApp.ViewModels;

public class MultipleChoiceQuestionViewModel : BaseViewModel
{
    private readonly NavigationStore _navigationStore;

    private readonly QuizManager _quizManager;

    public MultipleChoiceQuestionViewModel(MultipleChoiceQuestion question, QuizManager quizManager,
        NavigationStore navigationStore)
    {
        QuestionText = question.Question;
        Answers = new List<string>
            { question.CorrectAnswer, question.FalseAnswer1, question.FalseAnswer2, question.FalseAnswer3 };
        Answers = Answers.OrderBy(_ => Guid.NewGuid()).ToList();
        _quizManager = quizManager;
        _navigationStore = navigationStore;

        SubmitAnswerCommand = new RelayCommand(SubmitAnswer);
    }

    public string QuestionText { get; }
    public List<string> Answers { get; }

    public ICommand SubmitAnswerCommand { get; }

    private void SubmitAnswer()
    {
        //TODO auf SubmitAnswer des QuizManager zugreifen. Warte auf Implementierung 
        _navigationStore.CurrentViewModel = new QuizViewModel(_quizManager, _navigationStore);
    }
}