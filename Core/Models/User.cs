namespace QuizApp.Core;

public abstract class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public UserRole Role { get; init; }

    public virtual Quiz StartQuiz(List<Question> questions)
    {
        return new Quiz
        {
            Questions = questions,
            User = this,
            StartTime = DateTime.Now
        };
    }
}

public enum UserRole
{
    Admin,
    Player
}