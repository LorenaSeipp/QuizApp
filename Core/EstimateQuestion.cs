namespace QuizApp.Core
{
    public class EstimateQuestion : IQuestion
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Typ { get; set; }
        public int Difficulty { get; set; }
        public string Category { get; set; }
        public string RightAnswer { get; set; }

        public int CorrectValue { get; set; }

        public int AllowedMargin { get; set; }
    }
}