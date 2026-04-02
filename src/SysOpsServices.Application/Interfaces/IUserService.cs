using SysOpsServices.Application.DTOs;

namespace SysOpsServices.Application.Interfaces;

public interface IUserService
{
    Task<IEnumerable<UserDto>> GetAllAsync();
    Task<UserDto?> GetByIdAsync(int id);
}
