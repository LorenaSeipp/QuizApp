namespace QuizApp.Core.Models;

public class Player : User
{
    public int Id { get; init; }
    public int Highscore { get; set; }

    public int GamesPlayed { get; set; }
    public double AverageScore { get; set; }
    public DateTime? LastPlayed { get; set; }
}