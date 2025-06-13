using System.Collections.ObjectModel;
using System.Windows.Input;
using QuizApp.Commands;
using QuizApp.Core;
using QuizApp.Core.exceptions;

namespace QuizApp.ViewModels;

public class SortQuestionViewModel : BaseViewModel
{
    SortQuestion sortQuestion {get; set;}
    string currentItem {get; set;}

    private ObservableCollection<string> answersShuffled;
    private string[] answersInCorrectOrder;
    public ICommand MoveUpCommand => new RelayCommand(() => MoveAnswerUp(currentItem));
    public ICommand MoveDownCommand => new RelayCommand(() => MoveAnswerDown(currentItem));
    
    public SortQuestionViewModel(SortQuestion sortQuestion)
    {
        this.sortQuestion = sortQuestion;
        answersInCorrectOrder = new []{
            sortQuestion.Place1,
            sortQuestion.Place2,
            sortQuestion.Place3,
            sortQuestion.Place4
        };
        answersShuffled = new ObservableCollection<string>(ShuffleAnswers(answersInCorrectOrder));
    }

    public void MoveAnswerUp(string answer)
    {
        currentItem = answer;
        int indexOfAnswer = answersShuffled.IndexOf(answer);
        if (indexOfAnswer - 1 < 0)
        {
            throw new InvalidMoveException("Das Element kann nicht nach oben verschoben werden.");
        }
        string temp = answersShuffled[indexOfAnswer-1];
        answersShuffled[indexOfAnswer-1] = answer;
        answersShuffled[indexOfAnswer] = temp;
    }
    
    public void MoveAnswerDown(string answer)
    {
        currentItem = answer;
        int indexOfAnswer = answersShuffled.IndexOf(answer);
        if (indexOfAnswer + 1 > 3)
        {
            throw new InvalidMoveException("Das Element kann nicht nach unten verschoben werden.");
        }
        string temp = answersShuffled[indexOfAnswer+1];
        answersShuffled[indexOfAnswer+1] = answer;
        answersShuffled[indexOfAnswer] = temp;
    }

    public string[] ShuffleAnswers(string[] array)
    {
        Random random = new Random();
        for (int i = array.Length - 1; i > 0; i--)
        {
            //von 0 bis einschließlich i
            int j = random.Next(i + 1); 
            string temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
        return array;
    }

    public bool isRightOrder()
    {
        for (int i = 0; i < answersShuffled.Count; i++)
        {
            if (answersShuffled[i] != answersInCorrectOrder[i])
            {
                return false;
            }
        }
        return true;
    }
}