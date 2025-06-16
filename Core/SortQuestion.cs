namespace QuizApp.Core;

public class SortQuestion : IQuestion
{
    public SortQuestion(string question, QuestionEnums.Difficulty difficulty, string category, string place1,
        string place2, string place3,
        string place4)
    {
        Question = question;
        Difficulty = difficulty;
        Category = category;
        Place1 = place1;
        Place2 = place2;
        Place3 = place3;
        Place4 = place4;
    }

    public SortQuestion()
    {
    }

    public int Id { get; set; }
    public string Question { get; set; }
    public QuestionEnums.QuestionTyp Typ => QuestionEnums.QuestionTyp.Sort;
    public QuestionEnums.Difficulty Difficulty { get; set; }
    public string Category { get; set; }
    public string Place1 { get; set; }
    public string Place2 { get; set; }
    public string Place3 { get; set; }
    public string Place4 { get; set; }

    // Ergänzung: korrekte Reihenfolge als Liste
    public List<string> CorrectOrder => new List<string> { Place1, Place2, Place3, Place4 };


    public override string ToString()
    {
        return $"SortQuestion: Id={Id}, Type={Typ}, Difficulty={Difficulty}, Category={Category}, " +
               $"Question=\"{Question}\", Places=[{Place1}, {Place2}, {Place3}, {Place4}]";
    }
}