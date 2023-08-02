using DotNetServer.Core.Context;
using DotNetServer.Modules.UserContentModule.Entities;
using DotNetServer.Modules.UserContentModule.Model.DTO;
using Microsoft.EntityFrameworkCore;

namespace DotNetServer.Modules.UserContentModule.Repositories;

public class UserContentRepository : IUserContentRepository
{
    private readonly FoodbContext _context;

    public UserContentRepository(FoodbContext context)
    {
        _context = context;
    }

    public async Task<UserContent?> GetUserContentByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.UserContents.FindAsync(new object?[] { id }, cancellationToken);
    }

    public async Task AddUserContentAsync(UserContent userContent, CancellationToken cancellationToken)
    {
        _context.UserContents.Add(userContent);

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateUserContentAsync(Guid id, UserContent userContent, CancellationToken cancellationToken)
    {
        _context.Entry(userContent).State = EntityState.Modified;

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteUserContentAsync(Guid id, CancellationToken cancellationToken)
    {
        var userContent = await _context.UserContents.FindAsync(new object?[] { id }, cancellationToken);

        if (userContent is null) return;

        _context.UserContents.Remove(userContent);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<UserContent>> GetUserContentByUserIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.UserContents.Where(u => u.UserId == id).ToListAsync(cancellationToken);
    }

    public async Task<MacrosAndEnergy> GetMacrosAndEnergyAsync(Guid id, CancellationToken cancellationToken)
    {
        var dbResponse = await _context.UserContents
            .Where(u => u.UserId == id)
            .Where(u =>
                u.OrigSourceName == "PROTEIN" ||
                u.OrigSourceName == "CARBOHYDRATES" ||
                u.OrigSourceName == "FAT" ||
                u.OrigSourceName == "Energy"
            )
            .GroupBy(u => u.OrigSourceName)
            .ToListAsync(cancellationToken);

        var result = new MacrosAndEnergy();
        dbResponse.ForEach(row =>
        {
            switch (row.Key)
            {
                case "CARBOHYDRATES":
                    result.Carbs = row.ToList();
                    break;
                case "FAT":
                    result.Fats = row.ToList();
                    break;
                case "Energy":
                    result.Energy = row.ToList();
                    break;
                case "PROTEIN":
                    result.Proteins = row.ToList();
                    break;
            }
        });

        result.Energy = result.Energy.OrderBy(u => u.CreatedAt).ToList();
        result.Fats = result.Fats.OrderBy(u => u.CreatedAt).ToList();
        result.Carbs = result.Carbs.OrderBy(u => u.CreatedAt).ToList();
        result.Proteins = result.Proteins.OrderBy(u => u.CreatedAt).ToList();

        return result;
    }

    public async Task AddMultipleUserContentAsync(List<UserContent> userContents, CancellationToken cancellationToken)
    {
        _context.UserContents.AddRange(userContents);
        await _context.SaveChangesAsync(cancellationToken);
    }
}