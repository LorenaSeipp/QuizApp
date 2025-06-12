using QuizApp.Core;
using QuizApp.Infrastructure;

namespace QuizApp.Logic;

public class QuestionService
{
    private readonly QuestionRepository _repo;

    public QuestionService(string connectionString)
    {
        _repo = new QuestionRepository(connectionString);
    }

    public void AddMultipleChoiceQuestion(MultipleChoiceQuestion q)
    {
        _repo.AddMultipleChoiceQuestion(q);
    }

    //TODO: Weitere Methoden für Hinzufügen anderer Fragearten
}