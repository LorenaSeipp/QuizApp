using System.Data;
using Dapper;
using Oracle.ManagedDataAccess.Client;
using QuizApp.Core;

namespace QuizApp.Infrastructure;

public class QuestionRepository : IQuestionRepository
{
    private readonly string _connectionString;

    public QuestionRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    
    public List<SortQuestion> GetAllSortQuestions()
    {
        using (IDbConnection db = new OracleConnection(_connectionString))
        {
            string sql = "SELECT * FROM SortQuestion";
            List<SortQuestion> questions = db.Query<SortQuestion>(sql).AsList();
            return questions;
        }
    }
}