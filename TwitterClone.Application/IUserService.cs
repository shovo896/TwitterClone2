using TwitterClone.Application.Dtos;

namespace TwitterClone.Application;

public interface IUserService
{
    UserDto? CreateUser(CreateUserDtos createUserDto);
    UserDto? GetUserById(Guid id);
    IReadOnlyList<UserDto> GetUsers();
    UserDto? UpdateUser(Guid id, UpdateUserDtos updateUserDto);
    bool DeleteUser(Guid id);
}