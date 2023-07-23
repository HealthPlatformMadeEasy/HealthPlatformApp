using DotNetServer.Core.Entities.User;

namespace DotNetServer.Modules.UserContentModule.Repositories;

public interface IUserContentRepository
{
    UserContent GetUserContentById(Guid id);

    int CreateUserContent(UserContent userContent);

    int UpdateUserContent(Guid id, UserContent userContent);

    void DeleteUserContent(Guid id);
}