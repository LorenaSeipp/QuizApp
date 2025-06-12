using QuizApp.Infrastructure;
using QuizApp.Stores;
using QuizApp.ViewModels;

namespace QuizApp.Commands
{
    internal class NavigateSettingsCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;

        public NavigateSettingsCommand(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }

        public override void Execute(object parameter)
        {
            QuizManager quizManager = new QuizManager(App.ConnectionString)
            {
            };
            _navigationStore.CurrentViewModel = new SettingsViewModel(quizManager, _navigationStore);
        }
    }
}