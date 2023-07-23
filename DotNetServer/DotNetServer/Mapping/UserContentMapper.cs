using DotNetServer.Entities.User;
using DotNetServer.Model.Requests;
using Riok.Mapperly.Abstractions;

namespace DotNetServer.Mapping;

[Mapper]
public static partial class UserContentMapper
{
    public static partial UserContentRequest UserContentToUserContentRequest(UserContent userContent);

    public static partial UserContent UserContentRequestToUserContent(UserContentRequest userContentRequest);
}