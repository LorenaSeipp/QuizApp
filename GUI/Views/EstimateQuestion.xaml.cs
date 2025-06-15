using System.Windows.Controls;
using System.Windows.Input;

namespace QuizApp.Views
{
    public partial class EstimateQuestionView : UserControl
    {
        public EstimateQuestionView()
        {
            InitializeComponent();
        }
        
        private void NumberOnlyInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !int.TryParse(e.Text, out _);
        }

    }
}