using System.Data;
using Dapper;
using Oracle.ManagedDataAccess.Client;
using QuizApp.Core;

namespace QuizApp.Infrastructure;

public class QuestionRepository : IQuestionRepository
{
    private readonly string _connectionString;
    private IQuestionRepository _questionRepositoryImplementation;

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

    public List<MultipleChoiceQuestion> GetMultipleChoiceQuestionsByCategoryAndDifficulty(string category,
        int difficulty)
    {
        using IDbConnection db = new OracleConnection(_connectionString);
        string sql = "SELECT * FROM MultipleChoiceQuestion WHERE Category = :category AND Difficulty = :difficulty";
        return db.Query<MultipleChoiceQuestion>(sql, new { category, difficulty }).AsList();
    }

    public List<OpenQuestion> GetOpenQuestionsByCategoryAndDifficulty(string category, int difficulty)
    {
        using IDbConnection db = new OracleConnection(_connectionString);
        string sql = "SELECT * FROM OpenQuestion WHERE Category = :category AND Difficulty = :difficulty";
        return db.Query<OpenQuestion>(sql, new { category, difficulty }).AsList();
    }

    public List<EstimateQuestion> GetEstimateQuestionsByCategoryAndDifficulty(string category, int difficulty)
    {
        using IDbConnection db = new OracleConnection(_connectionString);
        string sql = "SELECT * FROM EstimateQuestion WHERE Category = :category AND Difficulty = :difficulty";
        return db.Query<EstimateQuestion>(sql, new { category, difficulty }).AsList();
    }

    public List<TrueFalseQuestion> GetTrueFalseQuestionsByCategoryAndDifficulty(string category, int difficulty)
    {
        using IDbConnection db = new OracleConnection(_connectionString);
        string sql = "SELECT * FROM TrueFalseQuestion WHERE Category = :category AND Difficulty = :difficulty";
        return db.Query<TrueFalseQuestion>(sql, new { category, difficulty }).AsList();
    }

    public List<SortQuestion> GetSortQuestionsByCategoryAndDifficulty(string category, int difficulty)
    {
        using IDbConnection db = new OracleConnection(_connectionString);
        string sql = "SELECT * FROM SortQuestion WHERE Category = :category AND Difficulty = :difficulty";
        return db.Query<SortQuestion>(sql, new { category, difficulty }).AsList();
    }


    // Methode zum Hinzufügen einer Multiple-Choice-Frage
    public void AddMultipleChoiceQuestion(MultipleChoiceQuestion question)
    {
        using (IDbConnection db = new OracleConnection(_connectionString))
        {
            string sql = @"
                INSERT INTO MultipleChoiceQuestion 
                    (QUESTION, TYP, DIFFICULTY, CATEGORY, CORRECTANSWER, FALSEANSWER1, FALSEANSWER2, FALSEANSWER3)
                VALUES 
                    (:question, :typ, :difficulty, :category, :correctAnswer, :falseAnswer1, :falseAnswer2, :falseAnswer3)";


            db.Execute(sql, new
            {
                question.Question,
                question.Typ,
                question.Difficulty,
                question.Category,
                question.CorrectAnswer,
                question.FalseAnswer1,
                question.FalseAnswer2,
                question.FalseAnswer3
            });
        }
    }

    public void AddSortQuestion(SortQuestion question)
    {
        using (IDbConnection db = new OracleConnection(_connectionString))
        {
            string sql = @"
            INSERT INTO SortQuestion 
                (Question, Typ, Difficulty, Category, Place1, Place2, Place3, Place4)
            VALUES 
                (:Question, :Typ, :Difficulty, :Category, :Place1, :Place2, :Place3, :Place4)";

            db.Execute(sql, new
            {
                question.Question,
                typ = question.Typ.ToString(),
                question.Difficulty,
                question.Category,
                question.Place1,
                question.Place2,
                question.Place3,
                question.Place4
            });
        }
    }

    public void AddEstimateQuestion(EstimateQuestion question)
    {
        using (IDbConnection db = new OracleConnection(_connectionString))
        {
            string sql = @"
        INSERT INTO EstimateQuestion 
            (Question, Typ, Difficulty, Category, RightAnswer)
        VALUES 
            (:Question, :Typ, :Difficulty, :Category, :RightAnswer)";

            db.Execute(sql, new
            {
                question.Question,
                typ = question.Typ.ToString(),
                question.Difficulty,
                question.Category,
                question.RightAnswer
            });
        }
    }

    public void AddTrueFalseQuestion(TrueFalseQuestion question)
    {
        using (IDbConnection db = new OracleConnection(_connectionString))
        {
            string sql = @"
        INSERT INTO TrueFalseQuestion 
            (Question, Typ, Difficulty, Category, TrueFalse)
        VALUES 
            (:Question, :Typ, :Difficulty, :Category, :TrueFalse)";

            db.Execute(sql, new
            {
                question.Question,
                typ = question.Typ.ToString(),
                question.Difficulty,
                question.Category,
                TrueFalse = question.TrueFalse ? 1 : 0
            });
        }
    }

    public void AddOpenQuestion(OpenQuestion question)
    {
        using (IDbConnection db = new OracleConnection(_connectionString))
        {
            string sql = @"
        INSERT INTO OpenQuestion 
            (Question, Typ, Difficulty, Category, Answer)
        VALUES 
            (:Question, :Typ, :Difficulty, :Category, :Answer)";

            db.Execute(sql, new
            {
                question.Question,
                typ = question.Typ.ToString(),
                question.Difficulty,
                question.Category,
                question.Answer
            });
        }
    }
}