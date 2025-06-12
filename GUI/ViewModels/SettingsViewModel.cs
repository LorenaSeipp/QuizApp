using System.Collections.ObjectModel;
using System.Windows.Input;
using QuizApp.Commands;
using QuizApp.Core;
using QuizApp.Infrastructure;
using QuizApp.Stores;

namespace QuizApp.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        private readonly NavigationStore _navigationStore;
        private readonly QuizManager _quizManager;

        private string _selectedCategory;

        private string _selectedDifficulty;

        public SettingsViewModel(QuizManager quizManager, NavigationStore navigationStore)
        {
            _quizManager = quizManager;
            _navigationStore = navigationStore;

            SelectedCategory = _quizManager.Category;

            // Schwierigkeitswerte initialisieren 
            SelectedDifficulty = _quizManager.Difficulty switch
            {
                QuestionEnums.Difficulty.leicht => "Einfach",
                QuestionEnums.Difficulty.mittel => "Mittel",
                QuestionEnums.Difficulty.schwer => "Schwer",
                _ => "Einfach" // Fallback, falls ungültig
            };

            NavigateQuizCommand = new NavigateQuizCommand(_navigationStore, _quizManager);
        }

        public ICommand NavigateQuizCommand { get; }

        // Kategorien + Schwierigkeitslevel als Properties
        public ObservableCollection<string> Categories { get; } = new ObservableCollection<string>
        {
            "Gemischt",
            "Musik",
            "Informatik",
            "Geografie",
            "Fun-Facts"
        };

        public ObservableCollection<string> Difficulties { get; } = new ObservableCollection<string>
        {
            "Einfach",
            "Mittel",
            "Schwer"
        };

        public string SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                if (SetProperty(ref _selectedCategory, value))
                {
                    _quizManager.Category = value;
                }
            }
        }

        public string SelectedDifficulty
        {
            get => _selectedDifficulty;
            set
            {
                if (SetProperty(ref _selectedDifficulty, value))
                {
                    _quizManager.Difficulty = ConvertDifficultyStringToEnum(value);
                }
            }
        }

        private QuestionEnums.Difficulty ConvertDifficultyStringToEnum(string diff)
        {
            return diff switch
            {
                "Einfach" => QuestionEnums.Difficulty.leicht,
                "Mittel" => QuestionEnums.Difficulty.mittel,
                "Schwer" => QuestionEnums.Difficulty.schwer,
                _ => throw new ArgumentException("Ungültiger Schwierigkeitswert")
            };
        }
    }
}