namespace QuizApp.Core
{
    public class TrueFalseQuestion : IQuestion
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Typ { get; set; }
        public int Difficulty { get; set; }
        public string Category { get; set; }
        public bool TrueFalse { get; set; }

        public bool IsTrue { get; set; }
    }
}