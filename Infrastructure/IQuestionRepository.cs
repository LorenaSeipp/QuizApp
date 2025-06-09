using QuizApp.Core;

namespace QuizApp.Infrastructure;

public interface IQuestionRepository
{
    List<SortQuestion> GetAllSortQuestions();
}