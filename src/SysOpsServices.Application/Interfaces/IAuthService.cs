using SysOpsServices.Application.DTOs;

namespace SysOpsServices.Application.Interfaces;

public interface IAuthService
{
    Task<LoginResponseDto?> LoginAsync(LoginRequestDto request);
}
