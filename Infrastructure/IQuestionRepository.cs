using QuizApp.Core;

namespace QuizApp.Infrastructure;

public interface IQuestionRepository
{
    List<SortQuestion> GetAllSortQuestions();
    List<MultipleChoiceQuestion> GetAllMultipleChoiceQuestions();
    List<EstimateQuestion> GetAllEstimateQuestions();
    List<TrueFalseQuestion> GetAllTrueFalseQuestions();
    List<OpenQuestion> GetAllOpenQuestions();
}