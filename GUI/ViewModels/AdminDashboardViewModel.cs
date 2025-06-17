using System.Windows;
using System.Windows.Input;
using QuizApp.Commands;
using QuizApp.Core;
using QuizApp.Infrastructure;
using QuizApp.Stores;

namespace QuizApp.ViewModels;

public class AdminDashboardViewModel : BaseViewModel
{
    private readonly NavigationStore _navigationStore;
    private readonly QuestionRepository _questionRepository;
    private readonly QuizManager _quizManager;
    private readonly RelayCommand _saveQuestionCommand;

    private string _category;
    private string _difficultyString;

    private string _questionText;

    private string _selectedQuestionType;

    private bool _trueFalse;

    private string _trueFalseString;

    public QuestionEnums.Difficulty Difficulty;

    public AdminDashboardViewModel(string connectionString, QuizManager quizManager, NavigationStore navigationStore)
    {
        _quizManager = quizManager;
        _navigationStore = navigationStore;
        _questionRepository = new QuestionRepository(connectionString);

        _saveQuestionCommand = new RelayCommand(SaveQuestion, CanSaveQuestion);
        NavigateHomeCommand = new NavigateHomeCommand(_navigationStore, _quizManager);
    }

    public ICommand SaveQuestionCommand => _saveQuestionCommand;
    public ICommand NavigateHomeCommand { get; }

    public string SelectedQuestionType
    {
        get => _selectedQuestionType;
        set
        {
            if (_selectedQuestionType != value)
            {
                _selectedQuestionType = value;
                OnPropertyChanged(nameof(SelectedQuestionType));
                OnPropertyChanged(nameof(IsMultipleChoiceVisible));
                OnPropertyChanged(nameof(IsEstimateVisible));
                OnPropertyChanged(nameof(IsTrueFalseVisible));
                OnPropertyChanged(nameof(IsSortVisible));
                OnPropertyChanged(nameof(IsOpenVisible));
                _saveQuestionCommand.RaiseCanExecuteChanged();
            }
        }
    }

    public bool IsMultipleChoiceVisible => SelectedQuestionType == "MultipleChoice";
    public bool IsEstimateVisible => SelectedQuestionType == "Estimate";
    public bool IsTrueFalseVisible => SelectedQuestionType == "TrueFalse";
    public bool IsSortVisible => SelectedQuestionType == "Sort";
    public bool IsOpenVisible => SelectedQuestionType == "Open";

    public string Category
    {
        get => _category;
        set
        {
            if (_category != value)
            {
                _category = value;
                OnPropertyChanged();
                _saveQuestionCommand.RaiseCanExecuteChanged();
            }
        }
    }

    public string QuestionText
    {
        get => _questionText;
        set
        {
            if (_questionText != value)
            {
                _questionText = value;
                OnPropertyChanged();
                _saveQuestionCommand.RaiseCanExecuteChanged();
            }
        }
    }

    public string DifficultyString
    {
        get => _difficultyString;
        set
        {
            if (_difficultyString != value)
            {
                _difficultyString = value;
                OnPropertyChanged();
                Difficulty = Enum.Parse<QuestionEnums.Difficulty>(_difficultyString);
                _saveQuestionCommand.RaiseCanExecuteChanged();
            }
        }
    }

    // MultipleChoice Properties
    public string CorrectAnswer { get; set; }
    public string FalseAnswer1 { get; set; }
    public string FalseAnswer2 { get; set; }
    public string FalseAnswer3 { get; set; }

    // Estimate Property
    public int RightAnswer { get; set; }

    public bool TrueFalse
    {
        get => _trueFalse;
        set
        {
            if (_trueFalse != value)
            {
                _trueFalse = value;
                OnPropertyChanged();
            }
        }
    }

    public string TrueFalseString
    {
        get => _trueFalseString;
        set
        {
            if (_trueFalseString != value)
            {
                _trueFalseString = value;
                OnPropertyChanged();

                // Hier die Umwandlung in bool
                TrueFalse = _trueFalseString?.ToLower() == "wahr";
            }
        }
    }

    // Sort Properties
    public string SortPlace1 { get; set; }
    public string SortPlace2 { get; set; }
    public string SortPlace3 { get; set; }
    public string SortPlace4 { get; set; }

    // Open Property
    public string OpenAnswer { get; set; }

    private bool CanSaveQuestion()
    {
        return !string.IsNullOrWhiteSpace(QuestionText)
               && !string.IsNullOrWhiteSpace(Category)
               && !string.IsNullOrWhiteSpace(SelectedQuestionType);
    }

    private void SaveQuestion()
    {
        switch (SelectedQuestionType)
        {
            case "MultipleChoice":
                MultipleChoiceQuestion mcq = new(QuestionText, Difficulty, Category, CorrectAnswer, FalseAnswer1,
                    FalseAnswer2, FalseAnswer3);
                _questionRepository.AddMultipleChoiceQuestion(mcq);
                MessageBox.Show(
                    $"MultipleChoice Frage gespeichert:\n{QuestionText}\nRichtige Antwort: {CorrectAnswer}");
                break;

            case "Estimate":
                EstimateQuestion eq = new(QuestionText, Difficulty, Category, RightAnswer);
                _questionRepository.AddEstimateQuestion(eq);
                MessageBox.Show($"Estimate Frage gespeichert:\n{QuestionText}\nAntwort: {RightAnswer}");
                break;

            case "TrueFalse":
                TrueFalseQuestion tfq = new(QuestionText, Difficulty, Category, TrueFalse);
                _questionRepository.AddTrueFalseQuestion(tfq);
                MessageBox.Show($"True/False Frage gespeichert:\n{QuestionText}\nAntwort: {TrueFalse}");
                break;

            case "Sort":
                SortQuestion sq = new(QuestionText, Difficulty, Category, SortPlace1, SortPlace2, SortPlace3,
                    SortPlace4);
                _questionRepository.AddSortQuestion(sq);
                MessageBox.Show(
                    $"Sort Frage gespeichert:\n{QuestionText}\nPlätze: {SortPlace1}, {SortPlace2}, {SortPlace3}, {SortPlace4}");
                break;

            case "Open":
                OpenQuestion oq = new(QuestionText, Difficulty, Category, OpenAnswer);
                _questionRepository.AddOpenQuestion(oq);
                MessageBox.Show($"Open Frage gespeichert:\n{QuestionText}\nAntwort: {OpenAnswer}");
                break;
        }
    }
}