using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Twitter_Clone.TwitterClone.Api.Data;
using TwitterClone.Api.Dtos;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]

public IActionResult CreateUser([FromBody] CreateUserDtos createUserDto)
{
    
    var createUser = _userService.CreateUser(createUserDto);
    if (createUser is null)
    {
        return BadRequest();
    }
    return Ok( new UserDto
    {
        id =createUser.Id , 
        FirstName = createUser.FirstName , 
        LastName =createUser.LastName , 
        Email = createUser.Email 
    })
}

public UserController (IUserService _userService){
    _userService = userService;
}

public sealed class UsersController(
    IConfiguration configuration,
    UserRepository userRepository) : ControllerBase

    [HttpGet]
    public ActionResult<IEnumerable<User>> GetUsers() =>
        Ok(userRepository.GetUsers());

   epository.AddUser(user);
        return
 

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
        
        public IActionResult GetUsers(Guid id) {
            

        } 

        }
