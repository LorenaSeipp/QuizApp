using System.Collections.ObjectModel;
using QuizApp.Core;
using QuizApp.Infrastructure;
using QuizApp.Stores;

namespace QuizApp.ViewModels;

public class SortQuestionViewModel : QuestionViewModel
{
    private readonly NavigationStore _navigationStore;
    private readonly SortQuestion _question;
    private readonly QuizManager _quizManager;

    // UserSortOrder speichert die aktuelle Reihenfolge der Items (z.B. als Liste)
    private ObservableCollection<string> _userSortOrder;

    public SortQuestionViewModel(SortQuestion question, QuizManager quizManager, NavigationStore navigationStore)
    {
        _question = question;
        _quizManager = quizManager;
        _navigationStore = navigationStore;

        // Die korrekte Reihenfolge aus der DB
        var correctOrder = new[] { _question.Place1, _question.Place2, _question.Place3, _question.Place4 };

        // Items, die der User sortieren soll, zufällig gemischt als Startpunkt
        var shuffled = correctOrder.OrderBy(x => Guid.NewGuid()).ToList();

        SortItems = new ObservableCollection<string>(shuffled);
        UserSortOrder = new ObservableCollection<string>(shuffled);
    }

    // ObservableCollection für die Items, die der User sortieren kann
    public ObservableCollection<string> SortItems { get; }

    public ObservableCollection<string> UserSortOrder
    {
        get => _userSortOrder;
        set
        {
            if (_userSortOrder != value)
            {
                _userSortOrder = value;
                OnPropertyChanged();
            }
        }
    }

    public string QuestionText => _question.Question;

    // Hier könntest du noch Commands hinzufügen, z.B. SubmitCommand oder ResetCommand
}