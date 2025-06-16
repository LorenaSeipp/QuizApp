namespace QuizApp.Core;

public class QuestionEnums
{
    public enum Category
    {
        Informatik,
        Musik,
        Geografie,
        FunFacts,
        Gemischt
    }

    public enum Difficulty
    {
        leicht = 0,
        mittel = 1,
        schwer = 2
    }

    public enum QuestionTyp
    {
        MultipleChoice = 0,
        Estimate = 1,
        TrueFalse = 2,
        Sort = 3,
        Open = 4
    }
}