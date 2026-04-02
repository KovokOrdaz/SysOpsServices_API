using System.Data;
using Dapper;
using SysOpsServices.Domain.Entities;
using SysOpsServices.Domain.Interfaces;
using SysOpsServices.Infrastructure.Data;

namespace SysOpsServices.Infrastructure.Repositories;

public class UserRepository(IDbConnectionFactory connectionFactory) : IUserRepository
{
    public async Task<IEnumerable<User>> GetAllAsync()
    {
        using IDbConnection db = connectionFactory.Create();
        return await db.QueryAsync<User>(SqlQueries.User.GetAll);
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        using IDbConnection db = connectionFactory.Create();
        return await db.QuerySingleOrDefaultAsync<User>(SqlQueries.User.GetById, new { Id = id });
    }

    public async Task<User?> GetByUsernameAsync(string username)
    {
        using IDbConnection db = connectionFactory.Create();
        return await db.QuerySingleOrDefaultAsync<User>(SqlQueries.User.GetByUsername, new { Username = username });
    }

    public async Task<int> CreateAsync(User user)
    {
        using IDbConnection db = connectionFactory.Create();
        return await db.ExecuteScalarAsync<int>(SqlQueries.User.Create, user);
    }

    public async Task<bool> UpdateAsync(User user)
    {
        using IDbConnection db = connectionFactory.Create();
        var rows = await db.ExecuteAsync(SqlQueries.User.Update, user);
        return rows > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        using IDbConnection db = connectionFactory.Create();
        var rows = await db.ExecuteAsync(SqlQueries.User.Delete, new { Id = id });
        return rows > 0;
    }
}
