using System.Windows;
using System.Windows.Controls;
using QuizApp.ViewModels;

namespace QuizApp.Views;

public partial class UserLoginView : UserControl
{
    public UserLoginView()
    {
        InitializeComponent();
    }

    private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
    {
        if (DataContext is UserLoginViewModel vm) vm.Password = ((PasswordBox)sender).Password;
    }
}