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

        //calculates points based on how close the guess was to the expected answer
        public int CalculatePoints(double userGuess)
        {
            bool isYearQuestion = Question.Contains("Jahr") || Question.Contains("Wann");

            double diff = Math.Abs(userGuess - RightAnswer);

            //flat margin for years
            if (isYearQuestion)
            {
                if (diff == 0) return 10;
                else if (diff <= 10) return 8;
                else if (diff <= 20) return 6;
                else if (diff <= 30) return 4;
                else if (diff <= 50) return 2;
                else return 0;
            }
            //percentage margin for everything else
            else
            {
                double percentOff = diff / RightAnswer * 100;

                if (percentOff == 0) return 10;
                else if (percentOff <= 5) return 8;
                else if (percentOff <= 15) return 6;
                else if (percentOff <= 25) return 4;
                else if (percentOff <= 40) return 2;
                else return 0;
            }
        }
    }

}