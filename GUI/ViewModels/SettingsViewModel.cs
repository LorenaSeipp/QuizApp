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
        private int? _selectedQuestionCount;
        
        public ICommand NavigateQuizCommand { get; }
        public ICommand SelectCategoryCommand { get; }
        public ICommand SelectDifficultyCommand { get; }
        public ICommand SelectQuestionCountCommand { get; }
        
        public ObservableCollection<string> Categories { get; }
        public ObservableCollection<string> Difficulties { get; }
        public ObservableCollection<int> QuestionCounts { get; }

        public SettingsViewModel(NavigationStore navigationStore, QuizManager quizManager)
        {
            _quizManager = quizManager;
            _navigationStore = navigationStore;

            Categories = new ObservableCollection<string>
            {
                "Gemischt",
                "Musik",
                "Informatik",
                "Geografie",
                "Fun-Facts"
            };

            Difficulties = new ObservableCollection<string>
            {
                "Einfach",
                "Mittel",
                "Schwer"
            };

            QuestionCounts = new ObservableCollection<int> { 5, 10, 15, 20 };

            // Default Werte (optional)
            SelectedCategory = null;
            SelectedDifficulty = null;
            SelectedQuestionCount = null;

            SelectCategoryCommand = new RelayCommandWithParam<string>(category =>
            {
                SelectedCategory = category;
            });

            SelectDifficultyCommand = new RelayCommandWithParam<string>(difficulty =>
            {
                SelectedDifficulty = difficulty;
            });

            SelectQuestionCountCommand = new RelayCommandWithParam<int>(count =>
            {
                SelectedQuestionCount = count;
            });

            NavigateQuizCommand = new NavigateQuizCommand(_navigationStore, _quizManager);
        }

        public string SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                if (SetProperty(ref _selectedCategory, value))
                {
                    _quizManager.Category = value;
                    OnPropertyChanged(nameof(CanStartQuiz));
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
                    OnPropertyChanged(nameof(CanStartQuiz));
                }
            }
        }

        public int? SelectedQuestionCount
        {
            get => _selectedQuestionCount;
            set
            {
                if (SetProperty(ref _selectedQuestionCount, value))
                {
                    _quizManager.NumberOfQuestions = value ?? 0;
                    OnPropertyChanged(nameof(CanStartQuiz));
                }
            }
        }
        
        public bool CanStartQuiz =>
            !string.IsNullOrEmpty(SelectedCategory) &&
            !string.IsNullOrEmpty(SelectedDifficulty) &&
            SelectedQuestionCount.HasValue;

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