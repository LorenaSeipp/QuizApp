namespace QuizApp.Core
{
    public class OpenQuestion : IQuestion
    {
        public OpenQuestion()
        {
        }

        public OpenQuestion(string question, QuestionEnums.Difficulty difficulty, string category, string answer)
        {
            Question = question;
            Difficulty = difficulty;
            Category = category;
            Answer = answer;
        }

        public int Id { get; set; }
        public string Question { get; set; }
        public QuestionEnums.QuestionTyp Typ => QuestionEnums.QuestionTyp.Open;
        public QuestionEnums.Difficulty Difficulty { get; set; }

        public string Category { get; set; }

        //First part of the string is the expected guess, the ones following (seperated by ',') are synonyms
        public string Answer { get; set; }
        public override string ToString()
        {
            return $"OpenQuestion: Id={Id}, Type={Typ}, Difficulty={Difficulty}, Category={Category}, " +
                   $"Question=\"{Question}\", PossibleAnswers={Answer}";
        }
    }
}