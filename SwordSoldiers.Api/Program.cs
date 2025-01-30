using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using SwordSoldiers.Api.Middlewares;
using SwordSoldiers.Api.Resources.ImageUpload;
using SwordSoldiers.Infrastructure;
using SwordSoldiers.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.AddServerHeader = false;
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins(
            "http://localhost:4200")
            .WithHeaders(new string[] {
                HeaderNames.ContentType,
                HeaderNames.Authorization,
            })
            .WithMethods("GET")
            .SetPreflightMaxAge(TimeSpan.FromSeconds(86400));
    });
});

builder.Configuration.AddUserSecrets<Program>();

var connectionString = builder.Configuration.GetConnectionString("Development");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddScoped<IImageUploadService, ImageUploadService>();
builder.Services.AddScoped<IApplicationUsersRepository, ApplicationUsersRepository>();
builder.Services.AddScoped<IGameMapRepository, GameMapRepository>();
builder.Services.AddScoped<IGameRepository, GameRepository>();

builder.Services.AddHttpClient();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.Authority = builder.Configuration["Security:Authority"];
    options.Audience = builder.Configuration["Security:Audience"];
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateAudience = true,
        ValidateIssuerSigningKey = true
    };
});

builder.Services.AddAuthorizationBuilder()
    .AddPolicy("CreateGameMaps", policy => policy.RequireClaim("permissions", "create:game-maps"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseHttpsRedirection();

app.MapControllers();
app.UseSecureHeaders();

app.UseAuthentication();
app.UseAuthorization();

app.Run();
