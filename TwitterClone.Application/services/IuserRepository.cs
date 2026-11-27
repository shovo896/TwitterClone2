using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Repositories;

public interface IUserRepository
{
    User? AddUser(User user);
    User? UpdateUser(User user);
    bool DeleteUser(Guid id);
    User? GetUserById(Guid id);
    User? GetUserByEmail(string email);
    IReadOnlyList<User> GetUsers();
}
