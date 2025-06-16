using QuizApp.Core;
using QuizApp.GUI.ViewModels;
using QuizApp.Infrastructure;
using QuizApp.Stores;
using QuizApp.ViewModels;

public static class QuestionViewModelFactory
{
    public static TimedQuestionViewModel Create(object question, NavigationStore navigationStore,
        QuizManager quizManager)
    {
        return question switch
        {
            MultipleChoiceQuestion mcq => new MultipleChoiceQuestionViewModel(mcq, navigationStore, quizManager),
            TrueFalseQuestion tfq => new TrueFalseQuestionViewModel(tfq, navigationStore, quizManager),
            EstimateQuestion eq => new EstimateQuestionViewModel(eq, navigationStore, quizManager),
            SortQuestion sq => new SortQuestionViewModel(sq, navigationStore, quizManager),
            OpenQuestion oq => new OpenQuestionViewModel(oq, navigationStore, quizManager),
            _ => throw new ArgumentException("Unbekannter Fragetyp")
        };
    }
}