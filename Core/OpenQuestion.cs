namespace QuizApp.Core
{
    public class OpenQuestion : IQuestion
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Typ { get; set; } // z. B. "Open"
        public int Difficulty { get; set; }
        public string Category { get; set; }
        public string Answer { get; set; }
    }
}