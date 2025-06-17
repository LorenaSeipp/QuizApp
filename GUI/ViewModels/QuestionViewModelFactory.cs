using QuizApp.Core;
using QuizApp.Infrastructure;
using QuizApp.Stores;

namespace QuizApp.ViewModels;

public static class QuestionViewModelFactory
{
    public static TimedQuestionViewModel Create(object question, NavigationStore navigationStore,
        QuizManager quizManager, Action onAnswerSubmitted)
    {
        return question switch
        {
            MultipleChoiceQuestion mcq => new MultipleChoiceQuestionViewModel(mcq, navigationStore, quizManager,
                onAnswerSubmitted),
            TrueFalseQuestion tfq => new TrueFalseQuestionViewModel(tfq, navigationStore, quizManager,
                onAnswerSubmitted),
            EstimateQuestion eq => new EstimateQuestionViewModel(eq, navigationStore, quizManager, onAnswerSubmitted),
            SortQuestion sq => new SortQuestionViewModel(sq, navigationStore, quizManager, onAnswerSubmitted),
            OpenQuestion oq => new OpenQuestionViewModel(oq, navigationStore, quizManager, onAnswerSubmitted),
            _ => throw new ArgumentException("Unbekannter Fragetyp")
        };
    }
}