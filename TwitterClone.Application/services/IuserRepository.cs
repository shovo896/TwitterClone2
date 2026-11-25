using TwitterClone.Domain.Entities;

namespace Twitter_Clone.TwitterClone.Application.services;

public class IuserRepository
{
   public  interface IUserRepository
    {
      User AddUser(User user); 
      
      User UpdateUser(User user);
      
      bool DeleteUser(Guid id); 
      bool DeleteUserById(Guid id); 
      
    }
}