using QuizApp.Infrastructure;
using QuizApp.Stores;

namespace QuizApp.ViewModels
{
    public class QuizViewModel : BaseViewModel
    {
        private readonly NavigationStore _navigationStore;
        private readonly QuizManager _quizManager;

        public QuizViewModel(QuizManager quizManager, NavigationStore navigationStore)
        {
            _quizManager = quizManager;
            _navigationStore = navigationStore;

            LoadNextQuestion();
        }

        private void LoadNextQuestion()
        {
            var nextQuestion = _quizManager.GetNextQuestion();
            if (nextQuestion == null)
            {
                _navigationStore.CurrentViewModel = new ResultViewModel(_quizManager, _navigationStore);
                return;
            }

            QuestionViewModel questionVM =
                QuestionViewModelFactory.Create(nextQuestion, _quizManager, _navigationStore);
            _navigationStore.CurrentViewModel = questionVM;
        }
    }
}