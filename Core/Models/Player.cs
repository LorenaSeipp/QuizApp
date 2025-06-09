namespace QuizApp.Core;

public class Player : User
{
    public int Highscore { get; set; }

    // List of all quizzes the player has completed

    public List<Quiz> History { get; set; } = new();

    public void AddToHistory(Quiz quiz)
    {
        History.Add(quiz);
    }

    public void UpdateHighscore(int score)
    {
        if (score > Highscore)
            Highscore = score;
    }
}