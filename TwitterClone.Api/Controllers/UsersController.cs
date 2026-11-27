using Microsoft.AspNetCore.Mvc;
using TwitterClone.Application;
using TwitterClone.Application.Dtos;

namespace TwitterClone.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class UsersController(IUserService userService) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType<IReadOnlyList<UserDto>>(StatusCodes.Status200OK)]
    public ActionResult<IReadOnlyList<UserDto>> GetUsers() =>
        Ok(userService.GetUsers());

    [HttpGet("{id:guid}")]
    [ProducesResponseType<UserDto>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<UserDto> GetUserById(Guid id)
    {
        var user = userService.GetUserById(id);
        return user is null ? NotFound() : Ok(user);
    }

    [HttpPost]
    [ProducesResponseType<UserDto>(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public ActionResult<UserDto> CreateUser([FromBody] CreateUserDtos createUserDto)
    {
        var user = userService.CreateUser(createUserDto);
        if (user is null)
        {
            return Conflict("A user with that email address already exists.");
        }

        return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType<UserDto>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<UserDto> UpdateUser(Guid id, [FromBody] UpdateUserDtos updateUserDto)
    {
        var user = userService.UpdateUser(id, updateUserDto);
        return user is null ? NotFound() : Ok(user);
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult DeleteUser(Guid id) =>
        userService.DeleteUser(id) ? NoContent() : NotFound();
}
