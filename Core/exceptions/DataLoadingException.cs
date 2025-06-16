namespace QuizApp.Core.Exceptions;

public class DataLoadingException : Exception
{
    public DataLoadingException(string message, Exception exception) : base(message, exception) { }
}