using DotNetServer.Core.Context;
using DotNetServer.Modules.NutrientModule.Entities;
using DotNetServer.Modules.NutrientModule.Model.DTO;
using Microsoft.EntityFrameworkCore;

namespace DotNetServer.Modules.NutrientModule.Repositories;

public class NutrientRepository : INutrientRepository
{
    private readonly NorwegianFoodDbContext _context;

    public NutrientRepository(NorwegianFoodDbContext context)
    {
        _context = context;
    }

    public async Task<Nutrient?> GetNutrientByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Nutrients.FindAsync(new object?[] { id }, cancellationToken);
    }

    public async Task AddNutrientAsync(Nutrient nutrient, CancellationToken cancellationToken)
    {
        await _context.Nutrients.AddAsync(nutrient, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task AddManyNutrientsAsync(List<Nutrient> nutrients, CancellationToken cancellationToken)
    {
        await _context.Nutrients.AddRangeAsync(nutrients, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteNutrientAsync(Guid id, CancellationToken cancellationToken)
    {
        var nutrient = await _context.Nutrients.FindAsync(new object?[] { id }, cancellationToken);

        if (nutrient is null) return;

        _context.Nutrients.Remove(nutrient);

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<EnergyAndMacros>?> GetEnergyAndMacros(Guid userId, CancellationToken cancellationToken)
    {
        return await _context.Nutrients.Where(nutrient => nutrient.UserId == userId)
            .Select(row => new EnergyAndMacros(
                row.CreatedAt,
                row.KilokalorierKcal,
                row.Fett,
                row.Karbohydrat,
                row.Protein))
            .ToListAsync(cancellationToken);
    }
}