using SysOpsServices.Application.DTOs;
using SysOpsServices.Application.Interfaces;

namespace SysOpsServices.Api.Endpoints;

public static class UserEndpoints
{
    public static IEndpointRouteBuilder MapUserEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/users")
                       .WithTags("Users")
                       .RequireAuthorization();

        // GET /api/users
        group.MapGet("/", async (IUserService service) =>
        {
            var users = await service.GetAllAsync();
            return Results.Ok(users);
        })
        .WithName("GetAllUsers")
        .WithSummary("Retorna la lista de todos los usuarios activos")
        .Produces<IEnumerable<UserDto>>(StatusCodes.Status200OK);

        // GET /api/users/{id}
        group.MapGet("/{id:int}", async (int id, IUserService service) =>
        {
            var user = await service.GetByIdAsync(id);
            return user is null
                ? Results.NotFound(new { Message = $"Usuario con Id={id} no encontrado." })
                : Results.Ok(user);
        })
        .WithName("GetUserById")
        .WithSummary("Retorna un usuario por su Id")
        .Produces<UserDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        return app;
    }
}
