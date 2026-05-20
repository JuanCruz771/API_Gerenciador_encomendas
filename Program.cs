using API_Gerendiador_Encomendas.DAO;
using API_Gerendiador_Encomendas.Repositories;
using API_Gerendiador_Encomendas.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirTudo", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "Minha API",
            Version = "v1"
        });

    c.AddSecurityDefinition("Bearer",
        new OpenApiSecurityScheme
        {
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            Scheme = "bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "Insira: Bearer {token}"
        });

    c.AddSecurityRequirement(
        new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference =
                        new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                },
                Array.Empty<string>()
            }
        });
});

var key = Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"]);

builder.Services
.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;

    options.SaveToken = true;

    options.TokenValidationParameters =
        new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,

            IssuerSigningKey =
                new SymmetricSecurityKey(key),

            ValidateIssuer = false,

            ValidateAudience = false
        };
});

builder.Services.AddAuthorization();

builder.Services.AddScoped<TokenService>();

builder.Services.AddScoped<iUserRepository, UserRepository>();

builder.Services.AddScoped<iEncomendaRepository, EncomendaRepository>();

builder.Services.AddScoped<iMoradorRepository, MoradorRepository>();

builder.Services.AddDbContext<ConnectionContext>(options =>
    options.UseNpgsql(
        "Host=" +
        "Port=;" +
        "Database=;" +
        "Username=;" +
        "Password="));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("PermitirTudo");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();