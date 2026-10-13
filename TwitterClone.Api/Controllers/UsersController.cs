using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TwitterClone.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class UsersController(IConfiguration configuration) : ControllerBase
{
    [HttpGet]
    public IActionResult GetUsers() => Ok(new[]
    {
        new { id = 1, name = "Shuvo", handle = "@shuvo" },
        new { id = 2, name = "CPS Academy", handle = "@cpsacademy" },
        new { id = 3, name = "ASP.NET Learner", handle = "@dotnetlearner" }
    });

    [HttpPost("app-info")]
    [Authorize]
    public IActionResult GetAppInfo() => Ok(new
    {
        appName = configuration["AppName"],
        environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"
    });
    
    // api id get
    
    
    
    [HttpGet("{id}")]

    public IActionResult GetUserById(Guid id) => Ok(new
        {
            userId = id,
            UserName = "user" + id.ToString(),


        }
    );
}
