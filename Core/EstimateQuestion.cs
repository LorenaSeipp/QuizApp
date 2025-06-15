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

        public int CalculatePoints(double userGuess)
        {
            bool isYearQuestion = Question.Contains("Jahr") || Question.Contains("Wann") || Question.Contains("wurde");

            double diff = Math.Abs(userGuess - CorrectValue);

            if (isYearQuestion)
            {
                if (diff == 0) return 10;
                else if (diff <= 10) return 8;
                else if (diff <= 20) return 6;
                else if (diff <= 30) return 4;
                else if (diff <= 50) return 2;
                else return 0;
            }
            else
            {
                double percentOff = diff / CorrectValue * 100;

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