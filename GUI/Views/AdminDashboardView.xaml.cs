using System.Windows.Controls;
using QuizApp.Infrastructure;
using QuizApp.Stores;
using QuizApp.ViewModels;

namespace QuizApp.Views;

public partial class AdminDashboardView : UserControl
{
    private readonly NavigationStore _navigationStore;
    private readonly QuizManager _quizManager;


    public AdminDashboardView()
    {
        InitializeComponent();
        DataContext = new AdminDashboardViewModel(App.ConnectionString, _quizManager, _navigationStore);
    }
}