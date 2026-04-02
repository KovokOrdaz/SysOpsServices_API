namespace SysOpsServices.Infrastructure.Data;

public static class SqlQueries
{
    public static class User
    {
        public const string GetAll = "SELECT id, name FROM user";
        
        public const string GetById = "SELECT Id, Username FROM user WHERE Id = @Id";
        
        public const string GetByUsername = "SELECT Id, Username, Password AS PasswordHash FROM user WHERE username = @Username";
        
        public const string Create = """
            INSERT INTO Users (Username, PasswordHash)
            VALUES (@Username, @PasswordHash);
            SELECT LAST_INSERT_ID();
            """;
            
        public const string Update = """
            UPDATE Users
            SET Username = @Username, PasswordHash = @PasswordHash
            WHERE Id = @Id
            """;
            
        public const string Delete = "DELETE FROM Users WHERE Id = @Id";
    }

    public static class Auth 
    {
        public const string Login = "SELECT id, name, password, role FROM user WHERE name = @name and password = @password";

        public const string Recovery = "SELECT Id, name, Password AS PasswordHash FROM user WHERE name = @name";
    }
}
