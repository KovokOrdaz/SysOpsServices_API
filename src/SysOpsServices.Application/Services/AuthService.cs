using SysOpsServices.Application.DTOs;
using SysOpsServices.Application.Interfaces;
using SysOpsServices.Domain.Interfaces;
using BC = BCrypt.Net.BCrypt;

namespace SysOpsServices.Application.Services;

public class AuthService(IAuthRepository authRepository, ITokenService tokenService) : IAuthService
{
    public async Task<LoginResponseDto?> LoginAsync(LoginRequestDto request)
    {
        var user = await authRepository.Login(request.Username, request.Password);
        
       //if (user == null || !BC.Verify(request.Password, user.Password)) return null;
       if (user == null || request.Password != user.Password) return null;

        var token = tokenService.GenerateToken(user);

        return new LoginResponseDto
        {
            Token = token
        };
    }
}
