using Microsoft.AspNetCore.Mvc;
using SysOpsServices.Application.DTOs;
using SysOpsServices.Application.Interfaces;

namespace SysOpsServices.Api.Endpoints;

public static class AuthEndpoints
{
    public static void MapAuthEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/auth").WithTags("Auth");

        group.MapPost("/login", async (
            [FromBody] LoginRequestDto request,
            [FromServices] IAuthService authService) =>
        {
            var response = await authService.LoginAsync(request);

            if (response == null) return Results.Unauthorized();

            return Results.Ok(response);
        })
        .WithName("Login");
    }
}
