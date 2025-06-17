using QuizApp.Core;

namespace QuizApp.Infrastructure;

public interface IQuestionRepository
{
    List<SortQuestion> GetAllSortQuestions();
    List<MultipleChoiceQuestion> GetAllMultipleChoiceQuestions();
    List<EstimateQuestion> GetAllEstimateQuestions();
    List<TrueFalseQuestion> GetAllTrueFalseQuestions();
    List<OpenQuestion> GetAllOpenQuestions();

    public List<MultipleChoiceQuestion> GetMultipleChoiceQuestionsByCategoryAndDifficulty(string category,
        int difficulty);

    public List<OpenQuestion> GetOpenQuestionsByCategoryAndDifficulty(string category, int difficulty);

    public List<EstimateQuestion> GetEstimateQuestionsByCategoryAndDifficulty(string category, int difficulty);

    public List<TrueFalseQuestion> GetTrueFalseQuestionsByCategoryAndDifficulty(string category, int difficulty);

    public List<SortQuestion> GetSortQuestionsByCategoryAndDifficulty(string category, int difficulty);
}