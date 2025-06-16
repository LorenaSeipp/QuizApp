using QuizApp.Core;
using QuizApp.Core.Models;
using QuizApp.Logic;

namespace QuizApp.Infrastructure
{
    public class QuizManager
    {
        private readonly UserService _userService;
        private List<IQuestion> _allQuestions;

        //*********** SPIELER ÄNDERUNGEN (SPIELER VON LOGIN MERKEN & Score va EndGame Methode durchreichen)*************
        private Stack<IQuestion> _questions;
        public List<IQuestion> AllQuestions = new();

        public QuizManager(string connectionString, IQuizTimer timer, UserService userService)
        {
            QuestionRepository questionRepo = new QuestionRepository(connectionString);
            _allQuestions = LoadAllQuestions(questionRepo);
            _questions = new Stack<IQuestion>(_allQuestions.OrderBy(q => Guid.NewGuid()));
            Score = 0;

            Timer = timer;
            Timer.TimeUp += OnTimeUp;
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }


        public IQuizTimer Timer { get; }

        public int Score { get; private set; }
        public int PointsPerRound { get; private set; }
        public int TotalQuestions => _allQuestions.Count;
        public int QuestionsAnswered => TotalQuestions - _questions.Count;
        public QuestionEnums.Difficulty Difficulty { get; set; }
        public QuestionEnums.Category Category { get; set; }
        public int NumberOfQuestions { get; set; } = 5;
        public Player CurrentPlayer { get; private set; }

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
            {
                int finalScore = Score;
                _userService.UpdatePlayerStats(CurrentPlayer.Id, finalScore);
                return null;
            }

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
                    if (oq.Answer.Trim().Equals(userAnswer?.ToString()?.Trim(), StringComparison.OrdinalIgnoreCase))
                        PointsPerRound += 10;
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

        public void SetCurrentPlayer(Player player)
        {
            CurrentPlayer = player;
        }
    }
}