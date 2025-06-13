namespace QuizApp.Core.exceptions;

public class InvalidMoveException: Exception
{ 
    public InvalidMoveException(string message) : base(message) { }
    
}