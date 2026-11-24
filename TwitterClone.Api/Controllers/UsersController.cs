using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Twitter_Clone.TwitterClone.Api.Data;
using TwitterClone.Api.Dtos;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public sealed class UsersController(
    IConfiguration configuration,
    UserRepository userRepository) : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<User>> GetUsers() =>
        Ok(userRepository.GetUsers());

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

        if (userRepository.GetUserByEmail(request.Email) is not null)
            return Conflict("A user with this email already exists.");

        var user = new User
        {
            FirstName = request.FirstName.Trim(),
            LastName = request.LastName.Trim(),
            Email = request.Email.Trim()
        };

        userRepository.AddUser(user);
        return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
    }

    [HttpGet("app-info")]
    public IActionResult GetAppInfo() => Ok(new
    {
        appName = configuration["AppName"],
        environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"
    });

    [HttpGet("{id:guid}")]
    public IActionResult GetUserById([FromRoute] Guid id) =>
        userRepository.GetUserById(id) is { } user ? Ok(user) : NotFound();

    [HttpPut("{id:guid}/phoneNumber")]
    public IActionResult UpdateUserPhoneNumber(
        [FromRoute] Guid id,
        [FromBody] string phoneNumber) =>
        UpdatePhoneNumber(id, phoneNumber);

    [HttpPatch("{id:guid}/phoneNumber")]
    public IActionResult PatchUserPhoneNumber(
        [FromRoute] Guid id,
        [FromBody] string phoneNumber) =>
        UpdatePhoneNumber(id, phoneNumber);

    [HttpDelete("{id:guid}/phoneNumber")]
    public IActionResult DeleteUserPhoneNumber([FromRoute] Guid id)
    {
        if (userRepository.GetUserById(id) is null)
            return NotFound();

        return NoContent();
    }

    private IActionResult UpdatePhoneNumber(Guid id, string phoneNumber)
    {
        if (userRepository.GetUserById(id) is null)
            return NotFound();

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
