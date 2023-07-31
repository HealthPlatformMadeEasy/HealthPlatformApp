using DotNetServer.Core.Wrappers;
using DotNetServer.Modules.UserContentModule.Mapping;
using DotNetServer.Modules.UserContentModule.Model.Requests;
using DotNetServer.Modules.UserContentModule.Model.Responses;
using DotNetServer.Modules.UserContentModule.Repositories;

namespace DotNetServer.Modules.UserContentModule.Services;

public class UserContentService : IUserContentService
{
    private readonly CancellationTokenSource _cancellationTokenSource = new();
    private readonly IUserContentRepository _userContentRepository;

    public UserContentService(IUserContentRepository userContentRepository)
    {
        _userContentRepository = userContentRepository;
        _cancellationTokenSource.CancelAfter(10000);
    }

    public async Task<Response<UserContentResponse>> GetUserContentAsync(Guid id)
    {
        try
        {
            var userContentDb =
                await _userContentRepository.GetUserContentByIdAsync(id, _cancellationTokenSource.Token);

            if (userContentDb is null)
                return new Response<UserContentResponse>
                {
                    Succeeded = false
                };

            var response = UserContentMapper.UserContentToUserContentResponse(userContentDb);

            return new Response<UserContentResponse>(response);
        }
        catch (Exception e)
        {
            return new Response<UserContentResponse>
            {
                Succeeded = false,
                Errors = e.Message
            };
        }
    }

    public async Task AddUserContentAsync(UserContentRequest userContentRequest)
    {
        var userContentDb = UserContentMapper.UserContentRequestToUserContent(userContentRequest);

        await _userContentRepository.AddUserContentAsync(userContentDb, _cancellationTokenSource.Token);
    }

    public async Task UpdateUserContentAsync(Guid id, UserContentRequest userContentRequest)
    {
        var userContentDb = UserContentMapper.UserContentRequestToUserContent(userContentRequest);

        await _userContentRepository.UpdateUserContentAsync(id, userContentDb, _cancellationTokenSource.Token);
    }

    public async Task DeleteUserContentAsync(Guid id)
    {
        await _userContentRepository.DeleteUserContentAsync(id, _cancellationTokenSource.Token);
    }

    public async Task<Response<List<UserContentResponse>>> GetUserContentByUserIdAsync(Guid id)
    {
        try
        {
            var responseDb =
                await _userContentRepository.GetUserContentByUserIdAsync(id, _cancellationTokenSource.Token);

            if (responseDb.Count == 0)
                return new Response<List<UserContentResponse>>
                {
                    Succeeded = false
                };

            var response = UserContentMapper.ListUserContentToListUserContentResponse(responseDb);

            return new Response<List<UserContentResponse>>(response);
        }
        catch (Exception e)
        {
            return new Response<List<UserContentResponse>>
            {
                Succeeded = false,
                Errors = e.Message
            };
        }
    }

    public async Task AddMultipleUserContentAsync(List<UserContentRequest> userContentRequests)
    {
        var userContents = UserContentMapper.ListUserContentRequestToUserContents(userContentRequests);
        await _userContentRepository.AddMultipleUserContentAsync(userContents, _cancellationTokenSource.Token);
    }

    public async Task<Response<MacrosAndEnergyResponse>> GetMacrosAndEnergyAsync(Guid id)
    {
        try
        {
            var responseDb = await _userContentRepository.GetMacrosAndEnergyAsync(id, _cancellationTokenSource.Token);

            var response = UserContentMapper.MacrosAndEnergyToMacrosAndEnergyResponse(responseDb);

            return new Response<MacrosAndEnergyResponse>(response);
        }
        catch (Exception e)
        {
            return new Response<MacrosAndEnergyResponse>
            {
                Succeeded = false,
                Errors = e.Message
            };
        }
    }
}