using TwitterClone.Application.Dtos;
using TwitterClone.Application.Repositories;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Services;

public sealed class UserService(IUserRepository userRepository) : IUserService
{
    public UserDto? CreateUser(CreateUserDtos createUserDto)
    {
        if (string.IsNullOrWhiteSpace(createUserDto.FirstName) ||
            string.IsNullOrWhiteSpace(createUserDto.LastName) ||
            string.IsNullOrWhiteSpace(createUserDto.Email))
        {
            return null;
        }

        var user = new User
        {
            FirstName = createUserDto.FirstName.Trim(),
            LastName = createUserDto.LastName.Trim(),
            Email = createUserDto.Email.Trim()
        };

        var createdUser = userRepository.AddUser(user);
        return createdUser is null ? null : ToDto(createdUser);
    }

    public UserDto? GetUserById(Guid id)
    {
        var user = userRepository.GetUserById(id);
        return user is null ? null : ToDto(user);
    }

    public IReadOnlyList<UserDto> GetUsers() =>
        userRepository.GetUsers().Select(ToDto).ToArray();

    public UserDto? UpdateUser(Guid id, UpdateUserDtos updateUserDto)
    {
        if (string.IsNullOrWhiteSpace(updateUserDto.FirstName) ||
            string.IsNullOrWhiteSpace(updateUserDto.LastName))
        {
            return null;
        }

        var user = userRepository.GetUserById(id);
        if (user is null)
        {
            return null;
        }

        user.FirstName = updateUserDto.FirstName.Trim();
        user.LastName = updateUserDto.LastName.Trim();
        var updatedUser = userRepository.UpdateUser(user);
        return updatedUser is null ? null : ToDto(updatedUser);
    }

    public bool DeleteUser(Guid id) => userRepository.DeleteUser(id);

    private static UserDto ToDto(User user) => new()
    {
        Id = user.Id,
        FirstName = user.FirstName,
        LastName = user.LastName,
        Email = user.Email
    };
}
