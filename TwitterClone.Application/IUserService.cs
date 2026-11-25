using TwitterClone.Application.Dtos;

namespace TwitterClone.Application;

public interface IUserService
{
    userDtos CreateUser(CreateUserDtos createUserDto); 
    UserDto GetUserById (Guid id);
    UserDto UpdateUser (Guid id, UpdateUserDtos updateUserDto); 
    bool DeleteUser (Guid id); 
    bool DeleteUserById (Guid id);
    
    
    
}