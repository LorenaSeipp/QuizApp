namespace QuizApp.Core;

public class IQuestion
{
    int Id { get; set; }
    string Question { get; set; }
    QuestionEnums.QuestionTyp Typ { get; }
    public QuestionEnums.Difficulty Difficulty { get; set; }
    public QuestionEnums.Category Category { get; set; }
}