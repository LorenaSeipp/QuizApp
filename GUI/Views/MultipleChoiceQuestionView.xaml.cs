using System.Windows;
using System.Windows.Controls;
using QuizApp.ViewModels;

namespace QuizApp.Views;

public partial class MultipleChoiceQuestionView : UserControl
{
    public MultipleChoiceQuestionView()
    {
        InitializeComponent();
    }

    private void RadioButton_Checked(object sender, RoutedEventArgs e)
    {
        if (DataContext is MultipleChoiceQuestionViewModel vm &&
            sender is RadioButton radio)
            vm.SelectedAnswer = radio.Tag?.ToString() ?? throw new InvalidOperationException();
    }
}