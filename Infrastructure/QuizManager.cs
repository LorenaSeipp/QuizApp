using QuizApp.Core;

namespace QuizApp.Infrastructure
{
    public class QuizManager
    {
        private List<IQuestion> _allQuestions;
        private Stack<IQuestion> _questions;
        public List<IQuestion> allQuestions = new();

        public QuizManager(string connectionString, IQuizTimer timer)
        {
            QuestionRepository questionRepo = new QuestionRepository(connectionString);
            _allQuestions = LoadAllQuestions(questionRepo);
            _questions = new Stack<IQuestion>(_allQuestions.OrderBy(q => Guid.NewGuid()));
            Score = 0;

            Timer = timer;
            Timer.TimeUp += OnTimeUp;
        }

        public IQuizTimer Timer { get; }

        public int Score { get; private set; }
        public int PointsPerRound { get; private set; }
        public int TotalQuestions => _allQuestions.Count;
        public int QuestionsAnswered => TotalQuestions - _questions.Count;
        public QuestionEnums.Difficulty Difficulty { get; set; }
        public QuestionEnums.Category Category { get; set; }
        public int NumberOfQuestions { get; set; } = 5;

        private List<IQuestion> LoadAllQuestions(QuestionRepository repo)
        {
            List<IQuestion> all = new();
            all.AddRange(repo.GetAllMultipleChoiceQuestions());
            all.AddRange(repo.GetAllTrueFalseQuestions());
            all.AddRange(repo.GetAllEstimateQuestions());
            all.AddRange(repo.GetAllSortQuestions());
            all.AddRange(repo.GetAllOpenQuestions());
            return all;
        }

        public void LoadQuestions(QuestionRepository repo, QuestionEnums.Category category,
            QuestionEnums.Difficulty difficulty)
        {
            List<IQuestion> questionsToLoad = new();
            int difficultyInt = (int)difficulty;

            if (category == QuestionEnums.Category.Gemischt)
            {
                // Hole alle Fragen aus allen Kategorien und filtere sie anschließend nach Difficulty
                questionsToLoad.AddRange(repo.GetAllMultipleChoiceQuestions()
                    .Where(q => (int)q.Difficulty == difficultyInt));
                questionsToLoad.AddRange(repo.GetAllTrueFalseQuestions()
                    .Where(q => (int)q.Difficulty == difficultyInt));
                questionsToLoad.AddRange(repo.GetAllEstimateQuestions().Where(q => (int)q.Difficulty == difficultyInt));
                questionsToLoad.AddRange(repo.GetAllSortQuestions().Where(q => (int)q.Difficulty == difficultyInt));
                questionsToLoad.AddRange(repo.GetAllOpenQuestions().Where(q => (int)q.Difficulty == difficultyInt));
            }
            else
            {
                string categoryStr = category.ToString();

                questionsToLoad.AddRange(
                    repo.GetMultipleChoiceQuestionsByCategoryAndDifficulty(categoryStr, difficultyInt));
                questionsToLoad.AddRange(repo.GetTrueFalseQuestionsByCategoryAndDifficulty(categoryStr, difficultyInt));
                questionsToLoad.AddRange(repo.GetEstimateQuestionsByCategoryAndDifficulty(categoryStr, difficultyInt));
                questionsToLoad.AddRange(repo.GetSortQuestionsByCategoryAndDifficulty(categoryStr, difficultyInt));
                questionsToLoad.AddRange(repo.GetOpenQuestionsByCategoryAndDifficulty(categoryStr, difficultyInt));
            }

            _allQuestions = questionsToLoad.OrderBy(q => Guid.NewGuid())
                .Take(NumberOfQuestions)
                .ToList();

            _questions = new Stack<IQuestion>(_allQuestions);
            Score = 0;
        }

        public IQuestion? GetNextQuestion()
        {
            if (_questions.Count == 0)
                return null;

            Timer.Reset();
            return _questions.Pop();
        }

        public void SubmitAnswer(IQuestion question, object? userAnswer, bool wasTimeUp = false)
        {
            Timer.Stop();
            PointsPerRound = 0;
            if (wasTimeUp) return;

            switch (question)
            {
                case EstimateQuestion eq:
                    PointsPerRound += eq.CalculatePoints((int)userAnswer);
                    break;
                case MultipleChoiceQuestion mcq:
                    if (mcq.CorrectAnswer.Equals(userAnswer))
                        PointsPerRound += 10;
                    break;
                case TrueFalseQuestion tfq:
                    if (tfq.IsTrue() == (bool)userAnswer)
                        PointsPerRound += 10;
                    break;
                case OpenQuestion oq:
                    if (userAnswer != null)
                    {
                        if (oq.Answer.Trim().ToLower().Split(',').Contains(userAnswer?.ToString().Trim().ToLower()))
                            PointsPerRound += 10;
                    }
                    break;
                case SortQuestion sq:
                    if ((bool)userAnswer)
                        PointsPerRound += 10;
                    break;
            }

            if (PointsPerRound > 0)
                PointsPerRound += Timer.RemainingSeconds / 3;

            Score += PointsPerRound;
        }

        private void OnTimeUp()
        {
        }
    }
}