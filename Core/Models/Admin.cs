namespace QuizApp.Core;

public class Admin : User
{
    // Adds a new question to the question pool (database).
    public void AddQuestion(Question question)
    {
        // TODO: connect to QuestionService
    }

    // Removes a question from question pool (database) based on its ID.
    public void DeleteQuestion(int questionId)
    {
        // TODO: connect to QuestionService
        Console.WriteLine($"Question with ID {questionId} deleted.");
    }
}