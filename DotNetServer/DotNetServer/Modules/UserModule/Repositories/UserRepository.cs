using DotNetServer.Core.Context;
using DotNetServer.Modules.UserModule.Entities;
using DotNetServer.Modules.UserModule.Model.Requests;
using Microsoft.EntityFrameworkCore;

namespace DotNetServer.Modules.UserModule.Repositories;

public class UserRepository : IUserRepository
{
    private readonly FoodbContext _context;

    public UserRepository(FoodbContext context)
    {
        _context = context;
    }

    public async Task<User?> GetUserByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested) throw new TaskCanceledException();

        return await _context.Users.FindAsync(new object?[] { id }, cancellationToken);
    }

    public async Task AddUserAsync(User user, CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested) throw new TaskCanceledException();

        _context.Users.Add(user);

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateUserAsync(Guid id, User user, CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested) throw new TaskCanceledException();

        _context.Entry(user).State = EntityState.Modified;
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteUserAsync(Guid id, CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested) throw new TaskCanceledException();

        var user = await _context.Users.FindAsync(new object?[] { id }, cancellationToken);

        if (user is null) return;

        _context.Users.Remove(user);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<User?> GetUserIdAsync(MinimalUserRequest minimalUserRequest, CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested) throw new TaskCanceledException();

        var user = await _context.Users.FirstOrDefaultAsync(user =>
            user.Email == minimalUserRequest.Email &&
            user.Name == minimalUserRequest.Name &&
            user.Password == minimalUserRequest.Password, cancellationToken);

        return user;
    }
}