using DotNetServer.Entities.User;

namespace DotNetServer.Repositories;

public interface IUserRepository
{
    User GetUserById(Guid id);

    int CreateUser(User user);

    int UpdateUser(Guid id, User user);

    void DeleteUser(Guid id);
}