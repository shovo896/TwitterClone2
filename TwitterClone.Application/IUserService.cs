using TwitterClone.Application.Dtos;

namespace TwitterClone.Application;

public interface IUserService
{
    userDtos CreateUser(CreateUserDtos createUserDto); 
    userDtos GetUserById (Guid id);
    CreateUserDtos UpdateUser (Guid id, UpdateUserDtos updateUserDto); 
    bool DeleteUser (Guid id); 
    UserDto UpadateUser (Guid id, UpdateUserDtos updateUserDto);
    bool DeleteUserById (Guid id);
    List <UserDtos>  GetUsers();
    
    
    
}