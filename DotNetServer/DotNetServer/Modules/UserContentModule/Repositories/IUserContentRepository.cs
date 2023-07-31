using DotNetServer.Modules.UserContentModule.Entities;
using DotNetServer.Modules.UserContentModule.Model.DTO;

namespace DotNetServer.Modules.UserContentModule.Repositories;

public interface IUserContentRepository
{
    Task<UserContent?> GetUserContentByIdAsync(Guid id, CancellationToken cancellationToken);

    Task AddUserContentAsync(UserContent userContent, CancellationToken cancellationToken);

    Task UpdateUserContentAsync(Guid id, UserContent userContent, CancellationToken cancellationToken);

    Task DeleteUserContentAsync(Guid id, CancellationToken cancellationToken);

    Task<List<UserContent>> GetUserContentByUserIdAsync(Guid id, CancellationToken cancellationToken);

    Task<MacrosAndEnergy> GetMacrosAndEnergyAsync(Guid id, CancellationToken cancellationToken);

    Task AddMultipleUserContentAsync(List<UserContent> userContents, CancellationToken cancellationToken);
}