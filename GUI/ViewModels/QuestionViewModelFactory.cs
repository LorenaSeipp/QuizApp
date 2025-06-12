using QuizApp.Core;
using QuizApp.GUI.ViewModels;
using QuizApp.Infrastructure;
using QuizApp.Stores;
using QuizApp.ViewModels;

public static class QuestionViewModelFactory
{
    public static QuestionViewModel Create(object question, QuizManager quizManager, NavigationStore navigationStore)
    {
        return question switch
        {
            MultipleChoiceQuestion mcq => new MultipleChoiceQuestionViewModel(mcq, quizManager, navigationStore),
            TrueFalseQuestion tfq => new TrueFalseQuestionViewModel(tfq, quizManager, navigationStore),
            EstimateQuestion eq => new EstimateQuestionViewModel(eq, quizManager, navigationStore),
            SortQuestion sq => new SortQuestionViewModel(sq, quizManager, navigationStore),
            OpenQuestion oq => new OpenQuestionViewModel(oq, quizManager, navigationStore),
            _ => throw new ArgumentException("Unbekannter Fragetyp")
        };
    }
}