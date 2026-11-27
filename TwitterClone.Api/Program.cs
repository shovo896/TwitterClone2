using TwitterClone.Api.Data;
using TwitterClone.Api.Options;
using TwitterClone.Api.Services;
using TwitterClone.Application;
using TwitterClone.Application.Repositories;
using TwitterClone.Application.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddProblemDetails();
builder.Services.AddSingleton<TweetStore>();
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services
    .AddOptions<TwitterSettings>()
    .Bind(builder.Configuration.GetSection(TwitterSettings.SectionName))
    .ValidateDataAnnotations()
    .ValidateOnStart();
builder.Services.AddSingleton<UserRepository>();

var app = builder.Build();

app.UseExceptionHandler();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.MapControllers();
app.MapGet("/health", () => Results.Ok(new { status = "Healthy", utc = DateTime.UtcNow }))
    .WithName("HealthCheck");

app.Run();

public partial class Program;
