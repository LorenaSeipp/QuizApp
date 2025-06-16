namespace QuizApp.Core.Models;

public class Player : User
{
    public int id { get; init; }
    public int Score { get; set; }
    public int Highscore { get; set; }

    public int GamesPlayed { get; set; }
    public double AverageScore { get; set; }
    public DateTime? LastPlayed { get; set; }

    public void UpdateHighscore(int score)
    {
        if (score > Highscore)
            Highscore = score;
    }

    public void UpdateStats(int newScore)
    {
        GamesPlayed++;
        AverageScore = (AverageScore * (GamesPlayed - 1) + newScore) / GamesPlayed;
        LastPlayed = DateTime.Now;
        UpdateHighscore(newScore);
    }
}