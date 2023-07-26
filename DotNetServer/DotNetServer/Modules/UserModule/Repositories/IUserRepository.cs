using DotNetServer.Modules.UserModule.Entities;
using DotNetServer.Modules.UserModule.Model.Requests;

namespace DotNetServer.Modules.UserModule.Repositories;

public interface IUserRepository
{
    User GetUserById(Guid id);

    int CreateUser(User user);

    int UpdateUser(Guid id, User user);

    void DeleteUser(Guid id);

    User GetUserId(MinimalUserRequest minimalUserRequest);
}