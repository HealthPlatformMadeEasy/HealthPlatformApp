using DotNetServer.Core.Context;
using DotNetServer.Modules.NorwegianFoodModule.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotNetServer.Modules.NorwegianFoodModule.Repositories;

public class NorwegianFoodRepository : INorwegianFoodRepository
{
    private readonly NorwegianFoodDbContext _context;

    public NorwegianFoodRepository(NorwegianFoodDbContext context)
    {
        _context = context;
    }

    public NorwegianFood? GetNorwegianFoodById(Guid id)
    {
        return _context.Foods.Find(id);
    }

    public async Task<NorwegianFood?> GetNorwegianFoodByName(string food, CancellationToken cancellationToken)
    {
        return await _context.Foods.FirstAsync(norwegianFood => norwegianFood.FoodName == food,
            cancellationToken);
    }

    public async Task<List<NorwegianFood>?> GetNorwegianFoodsByNameList(List<string> foodList,
        CancellationToken cancellationToken)
    {
        return await _context.Foods.Where(norwegianFood => foodList
                .Any(row => norwegianFood.FoodName == row))
            .ToListAsync(cancellationToken);
    }
}