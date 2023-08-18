using DotNetServer.Core.Wrappers;
using DotNetServer.Modules.UserModule.Mapping;
using DotNetServer.Modules.UserModule.Model.Requests;
using DotNetServer.Modules.UserModule.Model.Responses;
using DotNetServer.Modules.UserModule.Repositories;

namespace DotNetServer.Modules.UserModule.Services;

public class UserService : IUserService
{
    private readonly CancellationTokenSource _cancellationTokenSource = new();
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
        _cancellationTokenSource.CancelAfter(10000);
    }

    public async Task<Response<UserResponse>> GetUserAsync(Guid id)
    {
        try
        {
            var userDb = await _userRepository.GetUserByIdAsync(id, _cancellationTokenSource.Token);

            if (userDb is null)
                return new Response<UserResponse>
                {
                    Succeeded = false
                };


            var response = UserMapper.UserToUserResponse(userDb);

            return new Response<UserResponse>(response);
        }
        catch (Exception e)
        {
            return new Response<UserResponse>
            {
                Succeeded = false,
                Errors = e.Message
            };
        }
    }

    public async Task<Response<UserIdResponse>> AddUserAsync(MinimalUserRequest minimalUserRequest)
    {
        var userRequest = UserMapper.MinimalUserRequestToUser(minimalUserRequest);

        var userDb = UserMapper.UserRequestToUser(userRequest);

        try
        {
            await _userRepository.AddUserAsync(userDb, _cancellationTokenSource.Token);

            var response = new UserIdResponse(userDb.Id);

            return new Response<UserIdResponse>(response);
        }
        catch (Exception e)
        {
            return new Response<UserIdResponse>
            {
                Succeeded = false,
                Errors = e.Message
            };
        }
    }

    public async Task UpdateUserAsync(Guid id, UserRequest userRequest)
    {
        var userDb = UserMapper.UserRequestToUser(userRequest);

        await _userRepository.UpdateUserAsync(id, userDb, _cancellationTokenSource.Token);
    }

    public async Task DeleteUserAsync(Guid id)
    {
        await _userRepository.DeleteUserAsync(id, _cancellationTokenSource.Token);
    }

    public async Task<Response<UserIdResponse>> GetUserIdAsync(MinimalUserRequest minimalUserRequest)
    {
        try
        {
            var responseDb = await _userRepository.GetUserIdAsync(minimalUserRequest, _cancellationTokenSource.Token);

            if (responseDb is null)
                return new Response<UserIdResponse>
                {
                    Succeeded = false
                };

            var response = new UserIdResponse(responseDb.Id);

            return new Response<UserIdResponse>(response);
        }
        catch (Exception e)
        {
            return new Response<UserIdResponse>
            {
                Succeeded = false,
                Errors = e.Message
            };
        }
    }
}