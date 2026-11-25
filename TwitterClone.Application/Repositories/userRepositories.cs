using Twitter_Clone.TwitterClone.Application.services;
using TwitterClone.Domain.Entities;

namespace Twitter_Clone.TwitterClone.Api.Data;

public class UserRepository : IuserRepository 
{
    private readonly List<User> _users = new();

    public IReadOnlyCollection<User> GetUsers() => _users.AsReadOnly();

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

    public User? GetUserByEmail(string email)
    {
        return _users.SingleOrDefault(u =>
            string.Equals(u.Email, email, StringComparison.OrdinalIgnoreCase));
    }
}