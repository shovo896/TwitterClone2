using TwitterClone.Domain.Entities;

namespace Twitter_Clone.TwitterClone.Api.Data;

public class UserRepository
{
    
     private  List <User> _Users {get; set;}
    public User AddUser(User user)
    {
        
        _Users.Add(user);
        return user;
    }
}