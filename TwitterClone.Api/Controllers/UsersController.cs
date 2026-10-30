using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;
using TwitterClone.Api.Dtos;

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

    [HttpPost]
    [AllowAnonymous]
    public IActionResult CreateUser([FromBody] CreateUserDtos)
    {
        if (string.IsNullOrWhiteSpace(CreateUserDtos.FirstName) || string.IsNullOrWhiteSpace(CreateUserDtos.LastName) ||
            string.IsNullOrWhiteSpace(CreateUserDtos.Email))
        {
            return BadRequest("All fields are required.");
        }
        
        return Ok(new
            {
                UserId = Guid.NewGuid(),
                UserName = $"user{Guid.NewGuid()}"
            }
        ); 








    }

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
        return UpdatePhoneNumber(id, phoneNumber);
    }

    [HttpPatch("{id:guid}/phoneNumber")]
    public IActionResult PatchUserPhoneNumber(
        [FromRoute] Guid id,
        [FromBody] string phoneNumber)
    {
        return UpdatePhoneNumber(id, phoneNumber);
    }

    [HttpDelete("{id:guid}/phoneNumber")]
    public IActionResult DeleteUserPhoneNumber([FromRoute] Guid id)
    {
        return Ok(new
        {
            userId = id,
            Message= "User deleted sucessfully ", 
            userName = $"user{id}"

        });
    }

    private IActionResult UpdatePhoneNumber(Guid id, string phoneNumber)
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
