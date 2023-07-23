using DotNetServer.UserModule.Model.Requests;
using DotNetServer.UserModule.Model.Responses;

namespace DotNetServer.UserModule.Services;

public interface IUserService
{
    UserResponse GetUser(Guid id);

    bool CreateUser(UserRequest userRequest);

    bool UpdateUser(Guid id, UserRequest userRequest);

    void DeleteUser(Guid id);
}