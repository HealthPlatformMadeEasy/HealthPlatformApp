using DotNetServer.Core.Entities.User;
using DotNetServer.UserContentModule.Model.Requests;
using Riok.Mapperly.Abstractions;

namespace DotNetServer.UserContentModule.Mapping;

[Mapper]
public static partial class UserContentMapper
{
    public static partial UserContentRequest UserContentToUserContentRequest(UserContent userContent);

    public static partial UserContent UserContentRequestToUserContent(UserContentRequest userContentRequest);
}