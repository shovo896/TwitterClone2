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

    public User UpdateUser(User user)
    {
        _users.RemoveAll(u => u.ID == user.Id);
        _Users.Add(user);
        return user;
    }
}