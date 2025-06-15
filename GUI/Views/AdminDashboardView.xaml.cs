using System.Windows.Controls;
using QuizApp.Infrastructure;
using QuizApp.Logic;
using QuizApp.ViewModels;

namespace QuizApp.Views;

public partial class AdminDashboardView : UserControl
{
    private readonly QuestionService _questionService;
    private readonly QuizManager _quizManager;


    public AdminDashboardView()
    {
        
        InitializeComponent();
        DataContext = new AdminDashboardViewModel(App.ConnectionString, _quizManager);
    }
}