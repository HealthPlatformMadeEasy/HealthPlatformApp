using DotNetServer.Modules.UserContentModule.Entities;

namespace DotNetServer.Modules.UserContentModule.Repositories;

public interface IUserContentRepository
{
    UserContent GetUserContentById(Guid id);

    int CreateUserContent(UserContent userContent);

    int UpdateUserContent(Guid id, UserContent userContent);

    void DeleteUserContent(Guid id);

    List<UserContent> GetUserContentByUserId(Guid id);

    void CreateMultipleUserContent(List<UserContent> userContents);
}