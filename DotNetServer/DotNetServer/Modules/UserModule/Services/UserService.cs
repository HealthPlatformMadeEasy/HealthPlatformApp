using DotNetServer.Modules.UserModule.Mapping;
using DotNetServer.Modules.UserModule.Model.Requests;
using DotNetServer.Modules.UserModule.Model.Responses;
using DotNetServer.Modules.UserModule.Repositories;

namespace DotNetServer.Modules.UserModule.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public UserResponse GetUser(Guid id)
    {
        var userDb = _userRepository.GetUserById(id);

        return UserMapper.UserToUserResponse(userDb);
    }

    public UserIdResponse CreateUser(MinimalUserRequest minimalUserRequest)
    {
        var userRequestDb = UserMapper.MinimalUserRequestToUserRequest(minimalUserRequest);

        var userDb = UserMapper.UserRequestToUser(userRequestDb);

        var response = _userRepository.CreateUser(userDb);

        return new UserIdResponse(userDb.Id);
    }

    public bool UpdateUser(Guid id, UserRequest userRequest)
    {
        var userDb = UserMapper.UserRequestToUser(userRequest);

        var response = _userRepository.UpdateUser(id, userDb);

        return response > 0;
    }

    public void DeleteUser(Guid id)
    {
        _userRepository.DeleteUser(id);
    }

    public UserIdResponse GetUserId(MinimalUserRequest minimalUserRequest)
    {
        return new UserIdResponse(_userRepository.GetUserId(minimalUserRequest).Id);
    }
}