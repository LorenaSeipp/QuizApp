using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using QuizApp.GUI.ViewModels;

namespace QuizApp.Views
{
    public partial class SortQuestionView : UserControl
    {
        public SortQuestionView()
        {
            InitializeComponent();
        }

        private void MoveUp_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as SortQuestionViewModel;
            if (vm == null) return;

            int index = SortListBox.SelectedIndex;
            if (index > 0)
            {
                Swap(vm.UserSortOrder, index, index - 1);
                SortListBox.SelectedIndex = index - 1;
            }
        }

        private void MoveDown_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as SortQuestionViewModel;
            if (vm == null) return;

            int index = SortListBox.SelectedIndex;
            if (index < vm.UserSortOrder.Count - 1 && index >= 0)
            {
                Swap(vm.UserSortOrder, index, index + 1);
                SortListBox.SelectedIndex = index + 1;
            }
        }

        private void Swap(ObservableCollection<string> list, int indexA, int indexB)
        {
            var temp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = temp;
        }

        //TODO SubmitAnswer Button und Logik zur Überprüfung der Antwort 
    }
}