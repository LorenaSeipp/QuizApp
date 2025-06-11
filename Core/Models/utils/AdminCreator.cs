using System.Data;
using Oracle.ManagedDataAccess.Client;
using QuizApp.Core.Models.utils;

public class AdminCreator
{
    private readonly string _connectionString;

    public AdminCreator(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void CreateAdmin(string name, string password, string createdBy)
    {
        string hashedPassword = PasswordHelper.HashPassword(password);
        int userId;

        using OracleConnection connection = new(_connectionString);
        connection.Open();

        using OracleTransaction? transaction = connection.BeginTransaction();

        try
        {
            // Anlegen eines Users mit Role Admin in Users-Tabelle
            using (OracleCommand cmd = new(
                       "INSERT INTO Users (Name, Passwordhash, Role) VALUES (:name, :password, 'Admin') RETURNING UserId INTO :userId",
                       connection))
            {
                cmd.Parameters.Add(new OracleParameter("name", name));
                cmd.Parameters.Add(new OracleParameter("password", hashedPassword));
                OracleParameter userIdParam = new("userId", OracleDbType.Int32)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(userIdParam);
                cmd.ExecuteNonQuery();
                userId = Convert.ToInt32(userIdParam.Value.ToString());
            }

            // Anlegen des Admins in der Admins-Tabelle
            using (OracleCommand cmd = new(
                       "INSERT INTO Admins (Id, CreatedAt, CreatedBy, IsActive) VALUES (:id, :createdAt, :createdBy, :isActive)",
                       connection))
            {
                cmd.Parameters.Add(new OracleParameter("id", userId));
                cmd.Parameters.Add(new OracleParameter("createdAt", DateTime.UtcNow));
                cmd.Parameters.Add(new OracleParameter("createdBy", createdBy));
                cmd.Parameters.Add(new OracleParameter("isActive", 1));
                cmd.ExecuteNonQuery();
            }

            transaction.Commit();
            Console.WriteLine($"✅ Admin '{name}' wurde erfolgreich erstellt (UserId={userId}).");
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            Console.WriteLine($"Fehler beim Erstellen des Admins: {ex.Message}");
        }
    }
}