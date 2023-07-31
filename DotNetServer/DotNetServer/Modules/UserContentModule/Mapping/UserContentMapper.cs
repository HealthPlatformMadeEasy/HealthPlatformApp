using DotNetServer.Modules.UserContentModule.Entities;
using DotNetServer.Modules.UserContentModule.Model.DTO;
using DotNetServer.Modules.UserContentModule.Model.Requests;
using DotNetServer.Modules.UserContentModule.Model.Responses;
using Riok.Mapperly.Abstractions;

namespace DotNetServer.Modules.UserContentModule.Mapping;

[Mapper]
public static partial class UserContentMapper
{
    public static partial UserContentRequest UserContentToUserContentRequest(UserContent userContent);

    public static partial UserContent UserContentRequestToUserContent(UserContentRequest userContentRequest);

    public static partial UserContentResponse UserContentToUserContentResponse(UserContent userContent);

    public static partial List<UserContentResponse> ListUserContentToListUserContentResponse(
        List<UserContent> userContents);

    public static partial List<UserContent> ListUserContentRequestToUserContents(
        List<UserContentRequest> userContentRequests);

    public static partial MacrosAndEnergyResponse MacrosAndEnergyToMacrosAndEnergyResponse(
        MacrosAndEnergy macrosAndEnergy);
}