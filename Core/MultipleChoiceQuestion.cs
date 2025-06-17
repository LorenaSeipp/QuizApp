using QuizApp.Core;

public class MultipleChoiceQuestion : IQuestion
{
    public MultipleChoiceQuestion(string question, QuestionEnums.Difficulty difficulty, string category,
        string correctAnswer,
        string falseAnswer1, string falseAnswer2, string falseAnswer3)
    {
        Question = question;
        Typ = QuestionEnums.QuestionTyp.MultipleChoice;
        Difficulty = difficulty;
        Category = category;
        CorrectAnswer = correctAnswer;
        FalseAnswer1 = falseAnswer1;
        FalseAnswer2 = falseAnswer2;
        FalseAnswer3 = falseAnswer3;
    }

    public MultipleChoiceQuestion()
    {
    }

    public int Id { get; set; }
    public string Question { get; set; }
    public QuestionEnums.QuestionTyp Typ { get; set; }
    public QuestionEnums.Difficulty Difficulty { get; set; }
    public string Category { get; set; }
    public string CorrectAnswer { get; set; }
    public string FalseAnswer1 { get; set; }
    public string FalseAnswer2 { get; set; }
    public string FalseAnswer3 { get; set; }
}