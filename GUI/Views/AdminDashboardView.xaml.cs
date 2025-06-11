using System.Windows;
using System.Windows.Controls;
using QuizApp.Core;
using QuizApp.Logic;

namespace QuizApp.Views;

public partial class AdminDashboardView : Window
{
    private readonly QuestionService _questionService;


    public AdminDashboardView()
    {
        InitializeComponent();
        _questionService = new QuestionService(App.ConnectionString);
    }

    private void QuestionTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        MultipleChoicePanel.Visibility = Visibility.Collapsed;
        EstimatePanel.Visibility = Visibility.Collapsed;
        TrueFalsePanel.Visibility = Visibility.Collapsed;
        SortPanel.Visibility = Visibility.Collapsed;
        OpenPanel.Visibility = Visibility.Collapsed;

        string? selected = (QuestionTypeComboBox.SelectedItem as ComboBoxItem)?.Content?.ToString();

        switch (selected)
        {
            case "MultipleChoice":
                MultipleChoicePanel.Visibility = Visibility.Visible;
                break;
            case "Estimate":
                EstimatePanel.Visibility = Visibility.Visible;
                break;
            case "TrueFalse":
                TrueFalsePanel.Visibility = Visibility.Visible;
                break;
            case "Sort":
                SortPanel.Visibility = Visibility.Visible;
                break;
            case "Open":
                OpenPanel.Visibility = Visibility.Visible;
                break;
        }
    }

    private void SaveQuestion_Click(object sender, RoutedEventArgs e)
    {
        string category = CategoryTextBox.Text;
        int difficulty =
            int.TryParse(((ComboBoxItem)DifficultyComboBox.SelectedItem)?.Content?.ToString(), out int d) ? d : 0;
        string question = QuestionTextBox.Text;
        string questionType = (QuestionTypeComboBox.SelectedItem as ComboBoxItem)?.Content?.ToString();

        if (string.IsNullOrWhiteSpace(question) || string.IsNullOrWhiteSpace(category) ||
            string.IsNullOrWhiteSpace(questionType))
        {
            MessageBox.Show("Bitte alle Pflichtfelder ausfüllen!");
            return;
        }


        switch (questionType)
        {
            case "MultipleChoice":
                string right = RightAnswerTextBox.Text;
                string f1 = FalseAnswer1TextBox.Text;
                string f2 = FalseAnswer2TextBox.Text;
                string f3 = FalseAnswer3TextBox.Text;

                MultipleChoiceQuestion multipleChoiceQuestion = new(question, difficulty, category, right, f1, f2, f3);

                _questionService.AddMultipleChoiceQuestion(multipleChoiceQuestion);
                MessageBox.Show($"MultipleChoice Frage gespeichert:\n{question}\nRichtige Antwort: {right}");
                break;

            case "Estimate":
                string estimate = EstimateAnswerTextBox.Text;
                // TODO: Speichern in DB (Methode in QuestionService & QuestionRepository)
                MessageBox.Show($"Estimate Frage gespeichert:\n{question}\nRichtige Antwort: {estimate}");
                break;

            case "TrueFalse":
                bool isTrue = (TrueFalseComboBox.SelectedItem as ComboBoxItem)?.Tag?.ToString() == "1";
                // TODO: Speichern in DB (Methode in QuestionService & QuestionRepository)
                MessageBox.Show($"True/False Frage gespeichert:\n{question}\nAntwort: {isTrue}");
                break;

            case "Sort":
                string p1 = Place1TextBox.Text;
                string p2 = Place2TextBox.Text;
                string p3 = Place3TextBox.Text;
                string p4 = Place4TextBox.Text;
                // TODO: Speichern in DB (Methode in QuestionService & QuestionRepository)
                MessageBox.Show($"Sort Frage gespeichert:\n{question}\nPlätze: {p1}, {p2}, {p3}, {p4}");
                break;

            case "Open":
                string answer = OpenAnswerTextBox.Text;
                // TODO: Speichern in DB (Methode in QuestionService & QuestionRepository)
                MessageBox.Show($"Open Frage gespeichert:\n{question}\nAntwort: {answer}");
                break;
        }
    }
}