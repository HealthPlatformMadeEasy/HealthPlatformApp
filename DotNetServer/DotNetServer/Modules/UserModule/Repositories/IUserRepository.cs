using DotNetServer.Modules.UserModule.Entities;
using DotNetServer.Modules.UserModule.Model.Requests;

namespace DotNetServer.Modules.UserModule.Repositories;

public interface IUserRepository
{
    Task<User?> GetUserByIdAsync(Guid id, CancellationToken cancellationToken);

    Task AddUserAsync(User user, CancellationToken cancellationToken);

    Task UpdateUserAsync(Guid id, User user, CancellationToken cancellationToken);

    Task DeleteUserAsync(Guid id, CancellationToken cancellationToken);

    Task<User?> GetUserIdAsync(MinimalUserRequest minimalUserRequest, CancellationToken cancellationToken);
}