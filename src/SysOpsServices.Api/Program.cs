using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using SysOpsServices.Api.Endpoints;
using SysOpsServices.Application.Mappings;
using SysOpsServices.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// ── Authentication & Authorization (JWT) ──────────────────────────────────────
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
            ValidAudience = builder.Configuration["JwtSettings:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"]!))
        };
    });
builder.Services.AddAuthorization();

// ── OpenAPI / Scalar ─────────────────────────────────────────────────────────
builder.Services.AddOpenApi();

// ── AutoMapper (v13+ registration) ──────────────────────────────────────────
// El paquete de extensiones DI ya no es necesario, está incluido en AutoMapper core.
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<UserMappingProfile>());

// ── Infrastructure (DB connection, repositories, services) ───────────────────
var connectionString = builder.Configuration.GetConnectionString("ChampsToolsDB")
    ?? throw new InvalidOperationException("Connection string 'ChampsToolsDB' not found.");

builder.Services.AddInfrastructure(connectionString);

// ─────────────────────────────────────────────────────────────────────────────
var app = builder.Build();

if (app.Environment.IsDevelopment()) app.MapOpenApi();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

// ── Endpoints ─────────────────────────────────────────────────────────────────
app.MapAuthEndpoints();
app.MapUserEndpoints();

app.Run();
