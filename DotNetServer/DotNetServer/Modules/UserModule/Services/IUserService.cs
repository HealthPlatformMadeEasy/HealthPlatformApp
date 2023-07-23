using DotNetServer.Modules.UserModule.Model.Requests;
using DotNetServer.Modules.UserModule.Model.Responses;

namespace DotNetServer.Modules.UserModule.Services;

public interface IUserService
{
    UserResponse GetUser(Guid id);

    bool CreateUser(UserRequest userRequest);

    bool UpdateUser(Guid id, UserRequest userRequest);

    void DeleteUser(Guid id);
}