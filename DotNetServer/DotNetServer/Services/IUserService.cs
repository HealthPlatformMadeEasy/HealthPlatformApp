using DotNetServer.Model.Requests;

namespace DotNetServer.Services;

public interface IUserService
{
    bool GetUser(Guid id);

    bool CreateUser(UserRequest user);

    int UpdateUser(Guid id, UserRequest user);

    void DeleteUser(Guid id);
}