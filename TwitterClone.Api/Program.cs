using Twitter_Clone.TwitterClone.Api.Data;
using TwitterClone.Api.Options;
using TwitterClone.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddProblemDetails();
builder.Services.AddSingleton<TweetStore>();
builder.Services
    .AddOptions<TwitterSettings>()
    .Bind(builder.Configuration.GetSection(TwitterSettings.SectionName))
    .ValidateDataAnnotations()
    .ValidateOnStart();

var app = builder.Build();



// repositories registration 
builder.Services.AddSingleton<UserRepository>(); // its also an api 

app.UseExceptionHandler();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.MapControllers();
app.MapGet("/health", () => Results.Ok(new { status = "Healthy", utc = DateTime.UtcNow }))
    .WithName("HealthCheck");

app.Run();

public partial class Program;
