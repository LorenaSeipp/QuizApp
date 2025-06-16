namespace QuizApp.Core
{
    public class TrueFalseQuestion : IQuestion
    {
        public TrueFalseQuestion(string question, QuestionEnums.Difficulty difficulty, string category, bool trueFalse)
        {
            Question = question;
            Difficulty = difficulty;
            Category = category;
            TrueFalse = trueFalse;
        }

        public TrueFalseQuestion()
        {
        }

        public int Id { get; set; }
        public string Question { get; set; }
        public QuestionEnums.QuestionTyp Typ => QuestionEnums.QuestionTyp.Open;
        public QuestionEnums.Difficulty Difficulty { get; set; }
        public string Category { get; set; }
        public bool TrueFalse { get; set; }

        public bool IsTrue() => TrueFalse; 
    }
}