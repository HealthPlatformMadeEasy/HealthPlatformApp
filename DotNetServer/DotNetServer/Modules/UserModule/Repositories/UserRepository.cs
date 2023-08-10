using DotNetServer.Core.Context;
using DotNetServer.Modules.UserModule.Entities;
using DotNetServer.Modules.UserModule.Model.Requests;
using Microsoft.EntityFrameworkCore;

namespace DotNetServer.Modules.UserModule.Repositories;

public class UserRepository : IUserRepository
{
    private readonly NorwegianFoodDbContext _context;

    public UserRepository(NorwegianFoodDbContext context)
    {
        _context = context;
    }

    public async Task<User?> GetUserByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Users.FindAsync(new object?[] { id }, cancellationToken);
    }

    public async Task AddUserAsync(User user, CancellationToken cancellationToken)
    {
        await _context.Users.AddAsync(user, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateUserAsync(Guid id, User user, CancellationToken cancellationToken)
    {
        _context.Entry(user).State = EntityState.Modified;
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteUserAsync(Guid id, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FindAsync(new object?[] { id }, cancellationToken);

        if (user is null) return;

        _context.Users.Remove(user);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<User?> GetUserIdAsync(MinimalUserRequest minimalUserRequest, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FirstOrDefaultAsync(user =>
            user.Email == minimalUserRequest.Email &&
            user.Name == minimalUserRequest.Name &&
            user.Password == minimalUserRequest.Password, cancellationToken);

        return user;
    }
}