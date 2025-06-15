
namespace QuizApp.Core.Exceptions
{
    public class DatabaseInitializationException : Exception
    {
        public DatabaseInitializationException(string message, Exception exception) 
            : base(message, exception) { }
    }
}

