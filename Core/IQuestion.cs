namespace QuizApp.Core;

public class IQuestion
{
    int Id { get; set; }
    string Question { get; set; }
    QuestionEnums.QuestionTyp Typ { get; }
    QuestionEnums.Difficulty Difficulty { get; set; }
    QuestionEnums.Category Category { get; set; }
}