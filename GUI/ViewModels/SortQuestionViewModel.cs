using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using QuizApp.Core;
using QuizApp.Infrastructure;
using QuizApp.Stores;

namespace QuizApp.ViewModels;

public partial class SortQuestionViewModel : TimedQuestionViewModel
{
    private readonly SortQuestionAnswer[] _answersInCorrectOrder;
    private bool _hasAnswered;
    private SortQuestionAnswer? _selectedAnswer;

    public SortQuestionViewModel(SortQuestion sortQuestion, NavigationStore navigationStore, QuizManager quizManager,
        Action onQuestionHandled)
        : base(navigationStore, quizManager, onQuestionHandled)
    {
        SortQuestion = sortQuestion;
        _answersInCorrectOrder = new[]
        {
            new SortQuestionAnswer { QuestionText = sortQuestion.Place1 },
            new SortQuestionAnswer { QuestionText = sortQuestion.Place2 },
            new SortQuestionAnswer { QuestionText = sortQuestion.Place3 },
            new SortQuestionAnswer { QuestionText = sortQuestion.Place4 }
        };
        SortQuestionAnswer[] answersInWrongOrder = ShuffleAnswers(_answersInCorrectOrder.ToArray());
        ObservableCollection = new ObservableCollection<SortQuestionAnswer>(answersInWrongOrder);
    }

    public SortQuestionAnswer? SelectedAnswer
    {
        get => _selectedAnswer;
        set
        {
            if (_selectedAnswer != value)
            {
                _selectedAnswer = value;
                OnPropertyChanged(nameof(SelectedAnswer));
                NotifyCommands();
            }
        }
    }

    public bool HasAnswered
    {
        get => _hasAnswered;
        set
        {
            if (_hasAnswered != value)
            {
                _hasAnswered = value;
                OnPropertyChanged(nameof(HasAnswered));
                NotifyCommands();
                SubmitAnswerCommand.NotifyCanExecuteChanged();
            }
        }
    }

    public SortQuestion SortQuestion { get; set; }
    public string QuestionText => SortQuestion.Question;
    public bool IsRightOrder { get; set; }
    public ObservableCollection<SortQuestionAnswer> ObservableCollection { get; set; }

    private bool CanMoveAnswerUp(SortQuestionAnswer? answer)
    {
        if (HasAnswered || answer == null) return false;
        int index = ObservableCollection.IndexOf(answer);
        return index > 0;
    }

    private bool CanMoveAnswerDown(SortQuestionAnswer? answer)
    {
        if (HasAnswered || answer == null) return false;
        int index = ObservableCollection.IndexOf(answer);
        return index < ObservableCollection.Count - 1;
    }

    private void NotifyCommands()
    {
        MoveAnswerUpCommand.NotifyCanExecuteChanged();
        MoveAnswerDownCommand.NotifyCanExecuteChanged();
    }

    [RelayCommand(CanExecute = nameof(CanMoveAnswerUp))]
    public void MoveAnswerUp(SortQuestionAnswer answer)
    {
        int indexOfAnswer = ObservableCollection.IndexOf(answer);
        ObservableCollection.Move(indexOfAnswer, indexOfAnswer - 1);
        NotifyCommands();
    }

    [RelayCommand(CanExecute = nameof(CanMoveAnswerDown))]
    public void MoveAnswerDown(SortQuestionAnswer answer)
    {
        int indexOfAnswer = ObservableCollection.IndexOf(answer);
        ObservableCollection.Move(indexOfAnswer, indexOfAnswer + 1);
        NotifyCommands();
    }

    public SortQuestionAnswer[] ShuffleAnswers(SortQuestionAnswer[] array)
    {
        Random random = new Random();
        for (int i = array.Length - 1; i > 0; i--)
        {
            int j = random.Next(i + 1);
            SortQuestionAnswer temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        return array;
    }

    private bool CanCheckAnswer()
    {
        return !HasAnswered;
    }

    [RelayCommand(CanExecute = nameof(CanCheckAnswer))]
    public async void SubmitAnswer()
    {
        if (CanCheckAnswer())
        {
            IsRightOrder = true;
            for (int i = 0; i < ObservableCollection.Count; i++)
            {
                string correctOrder = _answersInCorrectOrder[i].QuestionText.Trim();
                string userOrder = ObservableCollection[i].QuestionText.Trim();
                bool isCorrect = string.Equals(correctOrder, userOrder, StringComparison.OrdinalIgnoreCase);
                ObservableCollection[i].IsCorrect = isCorrect;

                if (!isCorrect)
                {
                    IsRightOrder = false;
                }
            }

            HasAnswered = true;
            SelectedAnswer = null;
            SubmitAnswerCommand.NotifyCanExecuteChanged();
            NotifyCommands();

            // Submit the answer through the base class's internal method
            SubmitAnswerInternal(SortQuestion, IsRightOrder);
            // The remaining logic (OnPropertyChanged, WasTimeUp, message, await Task.Delay,
            // and ShowFeedbackAndProceedAsync) is now handled by SubmitAnswerInternal
        }
    }

    protected override async void OnTimeUp()
    {
        // Inform the QuizManager about time-up
        _quizManager.SubmitAnswer(SortQuestion, null, true);

        WasTimeUp = true;
        string message = "Richtige Reihenfolge: \n";
        foreach (SortQuestionAnswer answer in _answersInCorrectOrder) message += answer.QuestionText + "\n";
        message += $"Zeit abgelaufen!\nPunkte: {_quizManager.PointsPerRound}";

        // Use the base class method to show feedback and proceed
        await ShowFeedbackAndProceedAsync(message, true);
    }

    protected override string GetCorrectAnswerForQuestion(IQuestion question)
    {
        if (question is SortQuestion sq)
            // You might want to return a formatted string of the correct order
            return string.Join(" -> ", _answersInCorrectOrder.Select(a => a.QuestionText));

        return base.GetCorrectAnswerForQuestion(question);
    }

    public partial class SortQuestionAnswer : ObservableObject
    {
        [ObservableProperty] private bool? _isCorrect;

        public string QuestionText { get; set; }
    }
}