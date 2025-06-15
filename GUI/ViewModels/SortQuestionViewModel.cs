using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using QuizApp.Core;
using QuizApp.Infrastructure;
using QuizApp.Stores;

namespace QuizApp.ViewModels;

public partial class SortQuestionViewModel : BaseViewModel
{
    public partial class SortQuestionAnswer : ObservableObject
    {
        public string QuestionText { get; set; }
        
        [ObservableProperty]
        private bool? _isCorrect;
        
    }

    private SortQuestionAnswer? _selectedAnswer;
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
    
    private bool _hasAnswered;
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
                CheckAnswerCommand.NotifyCanExecuteChanged();
            }
        }
    }
    private readonly NavigationStore _navigationStore;
    private readonly QuizManager _quizManager;
    SortQuestion SortQuestion { get; set; }
    public string QuestionText => SortQuestion.Question;
    public bool IsRightOrder {get; set;}
    public ObservableCollection<SortQuestionAnswer> ObservableCollection { get; set; }
    private readonly SortQuestionAnswer[] _answersInCorrectOrder;

    public SortQuestionViewModel(SortQuestion sortQuestion, NavigationStore navigationStore, QuizManager quizManager)
    {
        _quizManager = quizManager;
        _navigationStore = navigationStore;
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
            //von 0 bis einschließlich i
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
    public void CheckAnswer()
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
            CheckAnswerCommand.NotifyCanExecuteChanged();
            NotifyCommands();
        }
    }
}