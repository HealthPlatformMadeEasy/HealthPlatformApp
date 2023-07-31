using DotNetServer.Core.Wrappers;
using DotNetServer.Modules.UserContentModule.Model.Requests;
using DotNetServer.Modules.UserContentModule.Model.Responses;

namespace DotNetServer.Modules.UserContentModule.Services;

public interface IUserContentService
{
    Task<Response<UserContentResponse>> GetUserContentAsync(Guid id);

    Task AddUserContentAsync(UserContentRequest userContentRequest);

    Task UpdateUserContentAsync(Guid id, UserContentRequest userContentRequest);

    Task DeleteUserContentAsync(Guid id);

    Task<Response<List<UserContentResponse>>> GetUserContentByUserIdAsync(Guid id);

    Task AddMultipleUserContentAsync(List<UserContentRequest> userContentRequests);

    Task<Response<MacrosAndEnergyResponse>> GetMacrosAndEnergyAsync(Guid id);
}