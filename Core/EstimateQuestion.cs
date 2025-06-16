namespace QuizApp.Core
{
    public class EstimateQuestion : IQuestion
    {
        public EstimateQuestion()
        {
        }

        public EstimateQuestion(string question, QuestionEnums.Difficulty difficulty, string category, int rightAnswer)
        {
            Question = question;
            Typ = QuestionEnums.QuestionTyp.Estimate;
            Difficulty = difficulty;
            Category = category;
            RightAnswer = rightAnswer;
        }

        public int Id { get; set; }
        public string Question { get; set; }
        public QuestionEnums.QuestionTyp Typ { get; set; }
        public QuestionEnums.Difficulty Difficulty { get; set; }
        public string Category { get; set; }
        public int RightAnswer { get; set; }
    }
}