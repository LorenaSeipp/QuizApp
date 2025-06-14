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


        public void LoadQuestions(QuestionRepository repo, string category, QuestionEnums.Difficulty difficulty)
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
                allQuestions.AddRange(repo.GetMultipleChoiceQuestionsByCategory(category));
                allQuestions.AddRange(repo.GetTrueFalseQuestionsByCategory(category));
                allQuestions.AddRange(repo.GetEstimateQuestionsByCategory(category));
                allQuestions.AddRange(repo.GetSortQuestionsByCategory(category));
                allQuestions.AddRange(repo.GetOpenQuestionsByCategory(category));
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
                OpenQuestion oq => oq.Answer.Trim().ToLower().Split(",")
                    .Contains(userAnswer.ToString()?.Trim().ToLower()),
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