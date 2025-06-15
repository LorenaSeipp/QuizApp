using QuizApp.Core;

namespace QuizApp.Infrastructure;

public interface IQuestionRepository
{
    List<SortQuestion> GetAllSortQuestions();
    List<MultipleChoiceQuestion> GetAllMultipleChoiceQuestions();
    List<EstimateQuestion> GetAllEstimateQuestions();
    List<TrueFalseQuestion> GetAllTrueFalseQuestions();
    List<OpenQuestion> GetAllOpenQuestions();

    List<SortQuestion> GetSortQuestionsByCategory(string category);
    List<OpenQuestion> GetOpenQuestionsByCategory(string category);
    List<MultipleChoiceQuestion> GetMultipleChoiceQuestionsByCategory(string category);
    List<EstimateQuestion> GetEstimateQuestionsByCategory(string category);
    List<TrueFalseQuestion> GetTrueFalseQuestionsByCategory(string category);
}