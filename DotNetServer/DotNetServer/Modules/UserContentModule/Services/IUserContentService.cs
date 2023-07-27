using DotNetServer.Modules.UserContentModule.Model.Requests;
using DotNetServer.Modules.UserContentModule.Model.Responses;

namespace DotNetServer.Modules.UserContentModule.Services;

public interface IUserContentService
{
    UserContentResponse GetUserContent(Guid id);

    bool CreateUserContent(UserContentRequest userContentRequest);

    bool UpdateUserContent(Guid id, UserContentRequest userContentRequest);

    void DeleteUserContent(Guid id);

    List<UserContentResponse> GetUserContentByUserId(Guid id);

    void CreateMultipleUserContent(List<UserContentRequest> userContentRequests);

    MacrosAndEnergyResponse GetMacrosAndEnergy(Guid id);
}