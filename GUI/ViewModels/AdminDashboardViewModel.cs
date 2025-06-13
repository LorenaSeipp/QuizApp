using System.Windows;
using System.Windows.Input;
using QuizApp.Commands;
using QuizApp.Core;
using QuizApp.Infrastructure;
using QuizApp.Logic;

namespace QuizApp.ViewModels;

public class AdminDashboardViewModel : BaseViewModel
{
    private readonly QuestionService _questionService;
    private readonly QuizManager _quizManager;

    private int _difficulty;

    private string _selectedQuestionType;

    // TrueFalse Property
    private string _trueFalseAnswer;

    public AdminDashboardViewModel(string connectionString, QuizManager quizManager)
    {
        _quizManager = quizManager;
        _questionService = new QuestionService(connectionString);
        SaveQuestionCommand = new RelayCommand(SaveQuestion, CanSaveQuestion);
    }

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
            }
        }
    }

    public bool IsMultipleChoiceVisible => SelectedQuestionType == "MultipleChoice";
    public bool IsEstimateVisible => SelectedQuestionType == "Estimate";
    public bool IsTrueFalseVisible => SelectedQuestionType == "TrueFalse";
    public bool IsSortVisible => SelectedQuestionType == "Sort";
    public bool IsOpenVisible => SelectedQuestionType == "Open";

    public string Category { get; set; }
    public string QuestionText { get; set; }

    public int Difficulty
    {
        get => _difficulty;
        set
        {
            if (_difficulty != value)
            {
                _difficulty = value;
                OnPropertyChanged(nameof(Difficulty));
            }
        }
    }

    // MultipleChoice Properties
    public string RightAnswer { get; set; }
    public string FalseAnswer1 { get; set; }
    public string FalseAnswer2 { get; set; }
    public string FalseAnswer3 { get; set; }

    // Estimate Property
    public string EstimateAnswer { get; set; }

    public string TrueFalseAnswer
    {
        get => _trueFalseAnswer;
        set
        {
            if (_trueFalseAnswer != value)
            {
                _trueFalseAnswer = value;
                OnPropertyChanged(nameof(TrueFalseAnswer));
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

    public ICommand SaveQuestionCommand { get; }

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
                MultipleChoiceQuestion mcq = new(QuestionText, Difficulty, Category, RightAnswer, FalseAnswer1,
                    FalseAnswer2, FalseAnswer3);
                _questionService.AddMultipleChoiceQuestion(mcq);
                MessageBox.Show(
                    $"MultipleChoice Frage gespeichert:\n{QuestionText}\nRichtige Antwort: {RightAnswer}");
                break;

            case "Estimate":
                // TODO: Speichern in DB (Methode in QuestionService & QuestionRepository)
                MessageBox.Show($"Estimate Frage gespeichert:\n{QuestionText}\nAntwort: {EstimateAnswer}");
                break;

            case "TrueFalse":
                bool isTrue = TrueFalseAnswer == "True";
                // TODO: Speichern in DB (Methode in QuestionService & QuestionRepository)
                MessageBox.Show($"True/False Frage gespeichert:\n{QuestionText}\nAntwort: {isTrue}");
                break;

            case "Sort":
                // TODO: Speichern in DB (Methode in QuestionService & QuestionRepository)
                MessageBox.Show(
                    $"Sort Frage gespeichert:\n{QuestionText}\nPlätze: {SortPlace1}, {SortPlace2}, {SortPlace3}, {SortPlace4}");
                break;

            case "Open":
                // TODO: Speichern in DB (Methode in QuestionService & QuestionRepository)
                MessageBox.Show($"Open Frage gespeichert:\n{QuestionText}\nAntwort: {OpenAnswer}");
                break;
        }
    }
}