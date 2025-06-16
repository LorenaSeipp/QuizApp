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

    public List<MultipleChoiceQuestion> GetMultipleChoiceQuestionsByCategory(string category)
    {
        using (IDbConnection db = new OracleConnection(_connectionString))
        {
            string sql = "SELECT * FROM MultipleChoiceQuestion WHERE Category = @Category";
            List<MultipleChoiceQuestion> questions = db.Query<MultipleChoiceQuestion>(sql).AsList();
            return questions;
        }
    }

    public List<OpenQuestion> GetOpenQuestionsByCategory(string category)
    {
        using (IDbConnection db = new OracleConnection(_connectionString))
        {
            string sql = "SELECT * FROM OpenQuestion WHERE Category = @Category";
            List<OpenQuestion> questions = db.Query<OpenQuestion>(sql).AsList();
            return questions;
        }
    }

    public List<EstimateQuestion> GetEstimateQuestionsByCategory(string category)
    {
        using (IDbConnection db = new OracleConnection(_connectionString))
        {
            string sql = "SELECT * FROM EstimateQuestion WHERE Category = @Category";
            List<EstimateQuestion> questions = db.Query<EstimateQuestion>(sql).AsList();
            return questions;
        }
    }

    public List<TrueFalseQuestion> GetTrueFalseQuestionsByCategory(string category)
    {
        using (IDbConnection db = new OracleConnection(_connectionString))
        {
            string sql = "SELECT * FROM TrueFalseQuestion WHERE Category = @Category";
            List<TrueFalseQuestion> questions = db.Query<TrueFalseQuestion>(sql).AsList();
            return questions;
        }
    }

    public List<SortQuestion> GetSortQuestionsByCategory(string category)
    {
        using (IDbConnection db = new OracleConnection(_connectionString))
        {
            string sql = "SELECT * FROM SortQuestion WHERE Category = @Category";
            List<SortQuestion> questions = db.Query<SortQuestion>(sql).AsList();
            return questions;
        }
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