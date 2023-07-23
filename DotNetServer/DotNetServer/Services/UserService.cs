using DotNetServer.Model.Requests;

namespace DotNetServer.Services;

public class UserService : IUserService
{
    public bool GetUser(Guid id)
    {
        throw new NotImplementedException();
    }

    public bool CreateUser(UserRequest user)
    {
        throw new NotImplementedException();
    }

    public int UpdateUser(Guid id, UserRequest user)
    {
        throw new NotImplementedException();
    }

    public void DeleteUser(Guid id)
    {
        throw new NotImplementedException();
    }
}