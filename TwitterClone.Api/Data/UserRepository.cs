using TwitterClone.Domain.Entities;

namespace Twitter_Clone.TwitterClone.Api.Data;

public class UserRepository
{
    private readonly List<User> _users = new();

    public User AddUser(User user)
    {
        _users.Add(user);
        return user;
    }

    public User UpdateUser(User user)
    {
        var index = _users.FindIndex(u => u.Id == user.Id);
        if (index >= 0)
        {
            _users[index] = user;
        }

        return user;
    }

    public User DeleteUser(User user)
    {
        _users.RemoveAll(u => u.Id == user.Id);
        return user;
    }

    public User? GetUserById(Guid id)
    {
        return _users.SingleOrDefault(u => u.Id == id);
    }
}