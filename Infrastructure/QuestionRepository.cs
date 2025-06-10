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
    
    public List<MultipleChoiceQuestion> GetAllMultipleChoiceQuestions()
    {
        using (IDbConnection db = new OracleConnection(_connectionString))
        {
            string sql = "SELECT * FROM MultipleChoiceQuestion";
            List<MultipleChoiceQuestion> questions = db.Query<MultipleChoiceQuestion>(sql).AsList();
            return questions;
        }
    }

    public List<EstimateQuestion> GetAllEstimateQuestions()
    {
        using (IDbConnection db = new OracleConnection(_connectionString))
        {
            string sql = "SELECT * FROM EstimateQuestion";
            List<EstimateQuestion> questions = db.Query<EstimateQuestion>(sql).AsList();
            return questions;
        }
    }

    public List<TrueFalseQuestion> GetAllTrueFalseQuestions()
    {
        using (IDbConnection db = new OracleConnection(_connectionString))
        {
            string sql = "SELECT * FROM TrueFalseQuestion";
            List<TrueFalseQuestion> questions = db.Query<TrueFalseQuestion>(sql).AsList();
            return questions;
        }
    }

    public List<OpenQuestion> GetAllOpenQuestions()
    {
        using (IDbConnection db = new OracleConnection(_connectionString))
        {
            string sql = "SELECT * FROM OpenQuestion";
            List<OpenQuestion> questions = db.Query<OpenQuestion>(sql).AsList();
            return questions;
        }
    }

}