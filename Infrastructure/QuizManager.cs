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
        public int PointsPerRound { get; private set; }
        public int TotalQuestions => _allQuestions.Count;
        public int QuestionsAnswered => TotalQuestions - _questions.Count;
        public QuestionEnums.Difficulty Difficulty { get; set; }
        public string Category { get; set; } = "Gemischt"; // z.B. "Musik", "Informatik", "Gemischt"
        public int NumberOfQuestions { get; set; } = 5; // Default Wert


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
            
            _allQuestions = allQuestions.OrderBy(q => Guid.NewGuid())
                .Take(NumberOfQuestions)
                .ToList();

            _questions = new Stack<IQuestion>(_allQuestions);
            Score = 0;
        }


        public IQuestion? GetNextQuestion()
        {
            if (_questions.Count == 0)
                return null;

            _timer.Reset();
            return _questions.Pop();
        }

        public void SubmitAnswer(IQuestion question, object? userAnswer, bool wasTimeUp= false)
        {
            _timer.Stop();
            PointsPerRound = 0;
            if (wasTimeUp)
            {
                return;
            }
            
            PointsPerRound += _timer.RemainingSeconds/3;;
            
            switch (question)
            {
                case EstimateQuestion eq:
                    int points = eq.CalculatePoints((int)userAnswer);
                    PointsPerRound += points;
                    break;

                case MultipleChoiceQuestion mcq:
                    if (mcq.CorrectAnswer.Equals(userAnswer))
                        PointsPerRound += 10;
                    break;

                case TrueFalseQuestion tfq:
                    if (tfq.IsTrue == (bool)userAnswer)
                        PointsPerRound += 10;
                    break;

                case OpenQuestion oq:
                    if (oq.Answer.Trim()
                        .Equals(userAnswer.ToString()?.Trim(), StringComparison.OrdinalIgnoreCase))
                        PointsPerRound += 10;
                    break;

                case SortQuestion sq:
                    if (sq.CorrectOrder.SequenceEqual((List<string>)userAnswer))
                        PointsPerRound += 10;
                    break;
            }

            Score += PointsPerRound;

        }

        private void OnTimeUp()
        { }
    }
}