using System.Data;
using Dapper;
using SysOpsServices.Domain.Entities;
using SysOpsServices.Domain.Interfaces;
using SysOpsServices.Infrastructure.Data;

namespace SysOpsServices.Infrastructure.Repositories;

public class AuthRepository(IDbConnectionFactory connectionFactory) : IAuthRepository
{
    public async Task<User?> Login(string Name, string Password)
    {
        using IDbConnection db = connectionFactory.Create();
        return await db.QuerySingleOrDefaultAsync<User>(SqlQueries.Auth.Login, new { Name, Password });
    }
}
