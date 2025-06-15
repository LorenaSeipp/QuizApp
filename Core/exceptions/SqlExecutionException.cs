namespace QuizApp.Core.Exceptions;

public class SqlExecutionException : Exception
{

    public SqlExecutionException(string sqlCommand, Exception exception) : base($"Fehler beim Ausführen des SQL-Kommandos:\n{sqlCommand}", exception) { }
}