using SysOpsServices.Domain.Entities;

namespace SysOpsServices.Application.Interfaces;

public interface ITokenService
{
    string GenerateToken(User user);
}
