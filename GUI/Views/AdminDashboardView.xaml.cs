using System.Windows.Controls;
using QuizApp.Logic;
using QuizApp.ViewModels;

namespace QuizApp.Views;

public partial class AdminDashboardView : UserControl
{
    private readonly QuestionService _questionService;


    public AdminDashboardView()
    {
        InitializeComponent();
        DataContext = new AdminDashboardViewModel(App.ConnectionString);
    }
}