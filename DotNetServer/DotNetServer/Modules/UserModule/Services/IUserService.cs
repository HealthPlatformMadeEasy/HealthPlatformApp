using DotNetServer.Core.Wrappers;
using DotNetServer.Modules.UserModule.Model.Requests;
using DotNetServer.Modules.UserModule.Model.Responses;

namespace DotNetServer.Modules.UserModule.Services;

public interface IUserService
{
    Task<Response<UserResponse>> GetUserAsync(Guid id);

    Task<Response<UserIdResponse>> AddUserAsync(MinimalUserRequest userRequest);

    Task UpdateUserAsync(Guid id, UserRequest userRequest);

    Task DeleteUserAsync(Guid id);

    Task<Response<UserIdResponse>> GetUserIdAsync(MinimalUserRequest minimalUserRequest);
}