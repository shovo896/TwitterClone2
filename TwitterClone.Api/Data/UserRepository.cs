using TwitterClone.Application.Repositories;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Api.Data;

public sealed class UserRepository : IUserRepository
{
    private readonly object _gate = new();
    private readonly Dictionary<Guid, User> _users = new();

    public IReadOnlyList<User> GetUsers()
    {
        lock (_gate)
        {
            return _users.Values.ToArray();
        }
    }

    public User? AddUser(User user)
    {
        lock (_gate)
        {
            if (_users.Values.Any(existing =>
                    string.Equals(existing.Email, user.Email, StringComparison.OrdinalIgnoreCase)))
            {
                return null;
            }

            _users.Add(user.Id, user);
            return user;
        }
    }

    public User? UpdateUser(User user)
    {
        lock (_gate)
        {
            if (!_users.ContainsKey(user.Id))
            {
                return null;
            }

            user.SetModified();
            _users[user.Id] = user;
            return user;
        }
    }

    public bool DeleteUser(Guid id)
    {
        lock (_gate)
        {
            return _users.Remove(id);
        }
    }

    public User? GetUserById(Guid id)
    {
        lock (_gate)
        {
            return _users.GetValueOrDefault(id);
        }
    }

    public User? GetUserByEmail(string email)
    {
        lock (_gate)
        {
            return _users.Values.SingleOrDefault(user =>
                string.Equals(user.Email, email, StringComparison.OrdinalIgnoreCase));
        }
    }
}