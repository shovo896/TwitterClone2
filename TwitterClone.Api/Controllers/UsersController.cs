using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Twitter_Clone.TwitterClone.Api.Data;
using TwitterClone.Api.Dtos;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public sealed class UsersController(IConfiguration configuration) : ControllerBase
{

    private readonly UserRepository _userRepository
    {
        _userRepository = userRepository; 
    }
    
   
    
    
    [HttpGet]
    public ActionResult<IEnumerable<object>> GetUsers() => Ok(new[]
    {
        new { id = 1, name = "Shuvo", handle = "@shuvo" },
        new { id = 2, name = "CPS Academy", handle = "@cpsacademy" },
        new { id = 3, name = "ASP.NET Learner", handle = "@dotnetlearner" }
    });

    [HttpPost]
    [AllowAnonymous]
    public IActionResult CreateUser([FromBody] CreateUserDtos request)
    {
        if (string.IsNullOrWhiteSpace(request.FirstName) ||
            string.IsNullOrWhiteSpace(request.LastName) ||
            string.IsNullOrWhiteSpace(request.Email))
        {
            return BadRequest("All fields are required.");
        }
        
        var  existingUser = _userRepository.GetUserByEmail(CreateUserDtos.Email);

        if (existingUser != null)
        {
            return BadRequest("User already exists.");
        }

        var user = new User
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email
        };

        var userRepository = new UserRepository();
        userRepository.AddUser(user);

        return Ok(new
        {
            UserId = user.Id,
            UserName = $"user{user.Id}"
        });
    }

    [HttpGet("app-info")]
    public IActionResult GetAppInfo() => Ok(new
    {
        appName = configuration["AppName"],
        environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"
    });

    [HttpGet("{id:guid}")]
    public IActionResult GetUserById([FromRoute] Guid id) => 
        
        Ok(new
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
            Message = "User deleted successfully",
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
