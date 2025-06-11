namespace QuizApp.Core.Models;

public abstract class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    public UserRole Role { get; set; }
}

public enum UserRole
{
    Admin,
    Player
}