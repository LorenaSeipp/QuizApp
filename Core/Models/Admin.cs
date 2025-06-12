namespace QuizApp.Core.Models;

public class Admin : User
{
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public string CreatedBy { get; set; }

    public bool IsActive { get; set; } = true;
}