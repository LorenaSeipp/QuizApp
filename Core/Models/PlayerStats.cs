namespace QuizApp.Core.Models;

public class PlayerStats
{
    public int GamesPlayed { get; set; }
    public int HighScore { get; set; }
    public double AverageScore { get; set; }
    public DateTime? LastPlayed { get; set; }
}