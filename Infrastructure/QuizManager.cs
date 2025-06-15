using QuizApp.Core;

namespace QuizApp.Infrastructure
{
    public class QuizManager
    {
        private List<IQuestion> _allQuestions;
        private Stack<IQuestion> _questions;
        
        private readonly IQuizTimer _timer;
        public IQuizTimer Timer => _timer;

        public QuizManager(string connectionString, IQuizTimer timer)
        {
            QuestionRepository questionRepo = new QuestionRepository(connectionString);
            _allQuestions = LoadAllQuestions(questionRepo);
            _questions = new Stack<IQuestion>(_allQuestions.OrderBy(q => Guid.NewGuid()));
            Score = 0;
            
            _timer = timer;
            _timer.TimeUp += OnTimeUp;
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
            while (_questions.Count > 0)
            {
                _timer.Reset();
                return _questions.Pop();
            }

            return null;
        }

        public void SubmitAnswer(IQuestion question, object? userAnswer, bool wasTimeUp= false)
        {
            _timer.Stop();
            if (wasTimeUp)
            {
                return;
            }
            switch (question)
            {
                case EstimateQuestion eq:
                    int points = eq.CalculatePoints((int)userAnswer);
                    Score += points;
                    break;

                case MultipleChoiceQuestion mcq:
                    if (mcq.CorrectAnswer.Equals(userAnswer))
                        Score += 10;
                    break;

                case TrueFalseQuestion tfq:
                    if (tfq.IsTrue == (bool)userAnswer)
                        Score += 10;
                    break;

                case OpenQuestion oq:
                    if (oq.Answer.Trim()
                        .Equals(userAnswer.ToString()?.Trim(), StringComparison.OrdinalIgnoreCase))
                        Score += 10;
                    break;

                case SortQuestion sq:
                    if (sq.CorrectOrder.SequenceEqual((List<string>)userAnswer))
                        Score += 10;
                    break;
            }

            Score += _timer.RemainingSeconds;
            
        }

        private void OnTimeUp()
        { }
    }
}