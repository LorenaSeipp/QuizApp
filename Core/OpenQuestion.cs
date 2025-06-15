namespace QuizApp.Core
{
    public class OpenQuestion : IQuestion
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public QuestionEnums.QuestionTyp Typ => QuestionEnums.QuestionTyp.Open;
        public int Difficulty { get; set; }

        public string Category { get; set; }

        //First part of the string is the expected guess, the ones following (seperated by ';') are synonyms
        public string Answer { get; set; }

        public override string ToString()
        {
            return $"OpenQuestion: Id={Id}, Type={Typ}, Difficulty={Difficulty}, Category={Category}, " +
                   $"Question=\"{Question}\", PossibleAnswers={Answer}";
        }
    }
}