using DotNetServer.Entities.User;

namespace DotNetServer.Repositories;

public interface IUserContentRepository
{
    UserContent GetUserContentById(Guid id);

    int CreateUserContent(UserContent userContent);

    int UpdateUserContent(Guid id, UserContent userContent);

    void DeleteUserContent(Guid id);
}