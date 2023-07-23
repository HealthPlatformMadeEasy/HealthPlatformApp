using DotNetServer.UserModule.Entities;
using DotNetServer.UserModule.Model.Requests;
using DotNetServer.UserModule.Model.Responses;
using Riok.Mapperly.Abstractions;

namespace DotNetServer.UserModule.Mapping;

[Mapper]
public static partial class UserMapper
{
    public static partial User UserRequestToUser(UserRequest userRequest);

    public static partial UserRequest UserToUserRequest(User user);

    public static partial UserResponse UserToUserResponse(User user);
}