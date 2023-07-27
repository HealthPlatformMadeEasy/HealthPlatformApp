using DotNetServer.Modules.UserContentModule.Mapping;
using DotNetServer.Modules.UserContentModule.Model.Requests;
using DotNetServer.Modules.UserContentModule.Model.Responses;
using DotNetServer.Modules.UserContentModule.Repositories;

namespace DotNetServer.Modules.UserContentModule.Services;

public class UserContentService : IUserContentService
{
    private readonly IUserContentRepository _userContentRepository;

    public UserContentService(IUserContentRepository userContentRepository)
    {
        _userContentRepository = userContentRepository;
    }

    public UserContentResponse GetUserContent(Guid id)
    {
        var userContentDb = _userContentRepository.GetUserContentById(id);

        return UserContentMapper.UserContentToUserContentResponse(userContentDb);
    }

    public bool CreateUserContent(UserContentRequest userContentRequest)
    {
        var userContentDb = UserContentMapper.UserContentRequestToUserContent(userContentRequest);

        var response = _userContentRepository.CreateUserContent(userContentDb);

        return response > 0;
    }

    public bool UpdateUserContent(Guid id, UserContentRequest userContentRequest)
    {
        var userContentDb = UserContentMapper.UserContentRequestToUserContent(userContentRequest);

        var response = _userContentRepository.UpdateUserContent(id, userContentDb);

        return response > 0;
    }

    public void DeleteUserContent(Guid id)
    {
        _userContentRepository.DeleteUserContent(id);
    }

    public List<UserContentResponse> GetUserContentByUserId(Guid id)
    {
        var response = _userContentRepository.GetUserContentByUserId(id);

        return UserContentMapper.ListUserContentToListUserContentResponse(response);
    }

    public void CreateMultipleUserContent(List<UserContentRequest> userContentRequests)
    {
        var userContents = UserContentMapper.ListUserContentRequestToUserContents(userContentRequests);
        _userContentRepository.CreateMultipleUserContent(userContents);
    }

    public MacrosAndEnergyResponse GetMacrosAndEnergy(Guid id)
    {
        var response = _userContentRepository.GetMacrosAndEnergy(id);

        return UserContentMapper.MacrosAndEnergyToMacrosAndEnergyResponse(response);
    }
}