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

        var Createuser = new CreateUser
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email
        };
        return Ok(new UserDtos
            {
                FirstName = CreateUserDtos.FirstName,
                LastName = CreateUserDtos.LastName,
                Email = CreateUserDtos.Email

            }
        ); 

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


    {

        vav user = _userRepository.GetUserById(id);
        if (User == null)
        {
            return Notfound(); 
            
        }

        return OkObjectResult(user); 
        
        
        
        
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

        if (user == null)
        {
            return NotFound(); 
        }

        var idDeleted = _userRepository.DeleteUser(user);
        if (!isDeleted)
        {
            return StatusCode(500,"An error occurred while deleting the user.");
        }
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
public IActionResult UpdateUser([FormRoute] Guid id, [FormBody] UpdateUserDtos updateUserDtos)
{
    var user = _userRepository.GetUserById(id);
    if (user == null)
    {
        return NotFound(); 
    }

    user.FirstName = updateUserDtos.FirstName;
    user.LastName = updateUserDtos.LastName;
    _userRepository.UpdateUser(user);
    return Ok(user
    );
}
