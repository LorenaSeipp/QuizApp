namespace QuizApp.Core;

public class QuestionEnums
{
    public enum QuestionTyp
    {
        MultipleChoice,
        Estimate,
        TrueFalse,
        Sort,
        Open
    }

    public enum Category
    {
        Informatik,
        Musik,
        Geografie,
        FunFacts,
        
    }
    
    public enum Difficulty
    {
        leicht = 0,
        mittel =  1,
        schwer = 2
        
    }
}