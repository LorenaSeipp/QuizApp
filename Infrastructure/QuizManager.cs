using QuizApp.Core;

namespace QuizApp.Infrastructure
{
    public class QuizManager
    {
        private List<IQuestion> _allQuestions;
        private Stack<IQuestion> _questions;

        public QuizManager(string connectionString)
        {
            QuestionRepository questionRepo = new QuestionRepository(connectionString);
            _allQuestions = LoadAllQuestions(questionRepo);
            _questions = new Stack<IQuestion>(_allQuestions.OrderBy(q => Guid.NewGuid()));
            Score = 0;
        }

        public int Score { get; private set; }
        public int TotalQuestions => _allQuestions.Count;
        public int QuestionsAnswered => TotalQuestions - _questions.Count;
        public QuestionEnums.Difficulty Difficulty { get; set; }
        public string Category { get; set; } = "Gemischt"; // z.B. "Musik", "Informatik", "Gemischt"

        private List<IQuestion> LoadAllQuestions(QuestionRepository repo)
        {
            var allQuestions = new List<IQuestion>();

            allQuestions.AddRange(repo.GetAllMultipleChoiceQuestions());
            allQuestions.AddRange(repo.GetAllTrueFalseQuestions());
            allQuestions.AddRange(repo.GetAllEstimateQuestions());
            allQuestions.AddRange(repo.GetAllSortQuestions());
            allQuestions.AddRange(repo.GetAllOpenQuestions());

            return allQuestions;
        }

        public void LoadAllQuestionsByCategory(QuestionRepository repo, string category, int difficulty)
        {
            var allQuestions = new List<IQuestion>();

            if (category == "Gemischt")
            {
                // Alle Kategorien laden
                allQuestions.AddRange(repo.GetAllMultipleChoiceQuestions());
                allQuestions.AddRange(repo.GetAllTrueFalseQuestions());
                allQuestions.AddRange(repo.GetAllEstimateQuestions());
                allQuestions.AddRange(repo.GetAllSortQuestions());
                allQuestions.AddRange(repo.GetAllOpenQuestions());
            }
            else
            {
                // Nur ausgewählte Kategorie laden
                switch (category)
                {
                    case "Musik":
                        allQuestions.AddRange(repo.GetMultipleChoiceQuestionsByCategory("Musik"));
                        allQuestions.AddRange(repo.GetTrueFalseQuestionsByCategory("Musik"));
                        allQuestions.AddRange(repo.GetEstimateQuestionsByCategory("Musik"));
                        allQuestions.AddRange(repo.GetSortQuestionsByCategory("Musik"));
                        allQuestions.AddRange(repo.GetOpenQuestionsByCategory("Musik"));
                        break;
                    case "Informatik":
                        allQuestions.AddRange(repo.GetMultipleChoiceQuestionsByCategory("Informatik"));
                        allQuestions.AddRange(repo.GetTrueFalseQuestionsByCategory("Informatik"));
                        allQuestions.AddRange(repo.GetEstimateQuestionsByCategory("Informatik"));
                        allQuestions.AddRange(repo.GetSortQuestionsByCategory("Informatik"));
                        allQuestions.AddRange(repo.GetOpenQuestionsByCategory("Informatik"));
                        break;
                    case "Geografie":
                        allQuestions.AddRange(repo.GetMultipleChoiceQuestionsByCategory("Geografie"));
                        allQuestions.AddRange(repo.GetTrueFalseQuestionsByCategory("Geografie"));
                        allQuestions.AddRange(repo.GetEstimateQuestionsByCategory("Geografie"));
                        allQuestions.AddRange(repo.GetSortQuestionsByCategory("Geografie"));
                        allQuestions.AddRange(repo.GetOpenQuestionsByCategory("Geografie"));
                        break;
                    case "Fun-Facts":
                        allQuestions.AddRange(repo.GetMultipleChoiceQuestionsByCategory("Fun-Facts"));
                        allQuestions.AddRange(repo.GetTrueFalseQuestionsByCategory("Fun-Facts"));
                        allQuestions.AddRange(repo.GetEstimateQuestionsByCategory("Fun-Facts"));
                        allQuestions.AddRange(repo.GetSortQuestionsByCategory("Fun-Facts"));
                        allQuestions.AddRange(repo.GetOpenQuestionsByCategory("Fun-Facts"));
                        break;
                }
            }

            // Schwierigkeitslevel filtern, wenn nicht Gemischt
            if (Enum.IsDefined(typeof(QuestionEnums.Difficulty), difficulty))
            {
                allQuestions = allQuestions.Where(q => q.Difficulty == (QuestionEnums.Difficulty)difficulty).ToList();
            }


            _allQuestions = allQuestions;
            _questions = new Stack<IQuestion>(_allQuestions.OrderBy(q => Guid.NewGuid()));
            Score = 0;
        }


        public void LoadQuestions(QuestionRepository repo, string category, int difficulty)
        {
            var allQuestions = new List<IQuestion>();

            if (category == "Gemischt")
            {
                // Alle Kategorien laden
                allQuestions.AddRange(repo.GetAllMultipleChoiceQuestions());
                allQuestions.AddRange(repo.GetAllTrueFalseQuestions());
                allQuestions.AddRange(repo.GetAllEstimateQuestions());
                allQuestions.AddRange(repo.GetAllSortQuestions());
                allQuestions.AddRange(repo.GetAllOpenQuestions());
            }
            else
            {
                // Nur ausgewählte Kategorie laden
                switch (category)
                {
                    case "Musik":
                        allQuestions.AddRange(repo.GetMultipleChoiceQuestionsByCategory("Musik"));
                        allQuestions.AddRange(repo.GetTrueFalseQuestionsByCategory("Musik"));
                        allQuestions.AddRange(repo.GetEstimateQuestionsByCategory("Musik"));
                        allQuestions.AddRange(repo.GetSortQuestionsByCategory("Musik"));
                        allQuestions.AddRange(repo.GetOpenQuestionsByCategory("Musik"));
                        break;
                    case "Informatik":
                        allQuestions.AddRange(repo.GetMultipleChoiceQuestionsByCategory("Informatik"));
                        allQuestions.AddRange(repo.GetTrueFalseQuestionsByCategory("Informatik"));
                        allQuestions.AddRange(repo.GetEstimateQuestionsByCategory("Informatik"));
                        allQuestions.AddRange(repo.GetSortQuestionsByCategory("Informatik"));
                        allQuestions.AddRange(repo.GetOpenQuestionsByCategory("Informatik"));
                        break;
                    case "Geografie":
                        allQuestions.AddRange(repo.GetMultipleChoiceQuestionsByCategory("Geografie"));
                        allQuestions.AddRange(repo.GetTrueFalseQuestionsByCategory("Geografie"));
                        allQuestions.AddRange(repo.GetEstimateQuestionsByCategory("Geografie"));
                        allQuestions.AddRange(repo.GetSortQuestionsByCategory("Geografie"));
                        allQuestions.AddRange(repo.GetOpenQuestionsByCategory("Geografie"));
                        break;
                    case "Fun-Facts":
                        allQuestions.AddRange(repo.GetMultipleChoiceQuestionsByCategory("Fun-Facts"));
                        allQuestions.AddRange(repo.GetTrueFalseQuestionsByCategory("Fun-Facts"));
                        allQuestions.AddRange(repo.GetEstimateQuestionsByCategory("Fun-Facts"));
                        allQuestions.AddRange(repo.GetSortQuestionsByCategory("Fun-Facts"));
                        allQuestions.AddRange(repo.GetOpenQuestionsByCategory("Fun-Facts"));
                        break;
                }
            }

            // Schwierigkeitslevel filtern, wenn nicht Gemischt
            if (Enum.IsDefined(typeof(QuestionEnums.Difficulty), difficulty))
            {
                allQuestions = allQuestions.Where(q => q.Difficulty == (QuestionEnums.Difficulty)difficulty).ToList();
            }

            _allQuestions = allQuestions;
            _questions = new Stack<IQuestion>(_allQuestions.OrderBy(q => Guid.NewGuid()));
            Score = 0;
        }


        public IQuestion? GetNextQuestion()
        {
            if (_questions.Count == 0)
                return null;

            return _questions.Pop();
        }

        public void SubmitAnswer(IQuestion question, object userAnswer)
        {
            bool isCorrect = question switch
            {
                MultipleChoiceQuestion mcq => mcq.CorrectAnswer.Equals(userAnswer),
                TrueFalseQuestion tfq => tfq.IsTrue == (bool)userAnswer,
                EstimateQuestion eq => Math.Abs(eq.CorrectValue - (int)userAnswer) <= eq.AllowedMargin,
                OpenQuestion oq => oq.Answer.Trim()
                    .Equals(userAnswer.ToString()?.Trim(), StringComparison.OrdinalIgnoreCase),
                SortQuestion sq => sq.CorrectOrder.SequenceEqual((List<string>)userAnswer),
                _ => false
            };

            if (isCorrect)
            {
                Score++;
            }
        }
    }
}