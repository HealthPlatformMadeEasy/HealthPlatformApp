using DotNetServer.Entities.User;
using DotNetServer.Model.Requests;
using Riok.Mapperly.Abstractions;

namespace DotNetServer.Mapping;

[Mapper]
public static partial class UserMapper
{
    public static partial User UserRequestToUser(UserRequest userRequest);

    public static partial UserRequest UserToUserRequest(User user);
}