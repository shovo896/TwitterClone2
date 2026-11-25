using TwitterClone.Application.Dtos;

namespace Twitter_Clone.TwitterClone.Application.services;

public class UserServices
{
    public interface UserServices : IUserService
    {
        userDtos CreateUserDto(CreateUserDtos createUserDtos);
        userDtos GetUserDtoById(Guid  id);
        
    }
    
    
}