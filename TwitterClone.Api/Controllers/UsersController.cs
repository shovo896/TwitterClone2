using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TwitterClone.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public sealed class UsersController(IConfiguration configuration) : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<object>> GetUsers() => Ok(new[]
    {
        new { id = 1, name = "Shuvo", handle = "@shuvo" },
        new { id = 2, name = "CPS Academy", handle = "@cpsacademy" },
        new { id = 3, name = "ASP.NET Learner", handle = "@dotnetlearner" }
    });

    [HttpGet("app-info")]
    public IActionResult GetAppInfo() => Ok(new
    {
        appName = configuration["AppName"],
        environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"
    });

    [HttpGet("{id:guid}")]
    public IActionResult GetUserById([FromRoute] Guid id) => Ok(new
    {
        userId = id,
        userName = $"user{id}"
    });

    [HttpPut("{id:guid}/phoneNumber")]
    public IActionResult UpdateUserPhoneNumber(
        [FromRoute] Guid id,
        [FromBody] string phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(phoneNumber))
        {
            return BadRequest("Phone number is required.");
        }

        return Ok(new
        {
            userId = id,
            phoneNumber
        });
    }
}
