namespace QuizApp.Core;

public class SortQuestion : IQuestion
{
    public int Id { get; set; }
    public string Question { get; set; }
    public QuestionEnums.QuestionTyp Typ => QuestionEnums.QuestionTyp.Sort;
    public int Difficulty { get; set; } 
    public string Category { get; set; }
    public string Place1 { get; set; }
    public string Place2 { get; set; }
    public string Place3 { get; set; }
    public string Place4 { get; set; }
    
    public override string ToString()
    {
        return $"SortQuestion: Id={Id}, Difficulty={Difficulty}, Category={Category}, " +
               $"Question=\"{Question}\", Places=[{Place1}, {Place2}, {Place3}, {Place4}]";
    }
}