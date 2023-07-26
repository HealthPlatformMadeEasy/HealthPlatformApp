using DotNetServer.Modules.UserModule.Entities;
using DotNetServer.Modules.UserModule.Model.Requests;
using DotNetServer.Modules.UserModule.Model.Responses;
using Riok.Mapperly.Abstractions;

namespace DotNetServer.Modules.UserModule.Mapping;

[Mapper]
public static partial class UserMapper
{
    public static partial User UserRequestToUser(UserRequest userRequest);

    public static partial UserRequest UserToUserRequest(User user);

    public static partial UserResponse UserToUserResponse(User user);

    public static partial UserRequest MinimalUserRequestToUserRequest(MinimalUserRequest userRequest);
}