using DotNetServer.Core.Context;
using DotNetServer.Modules.FoodModule.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotNetServer.Modules.FoodModule.Repositories;

public class FoodRepository : IFoodRepository
{
    private readonly FoodbContext _context;

    public FoodRepository(FoodbContext context)
    {
        _context = context;
    }

    public async Task<List<Food>> GetFood(string foodName, CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested) throw new TaskCanceledException();

        var response = await _context.Foods.Where(food => food.Name == foodName)
            .Include(prop => prop.Contents)
            .Select(food => new Food
            {
                Name = food.Name,
                Description = food.Description,
                FoodGroup = food.FoodGroup,
                Contents = food.Contents.Select(cont => new Content
                {
                    OrigContent = cont.OrigContent,
                    SourceType = cont.SourceType,
                    StandardContent = cont.StandardContent,
                    OrigSourceName = cont.OrigSourceName,
                    OrigUnit = cont.OrigUnit
                }).ToList()
            }).ToListAsync(cancellationToken);

        return response;
    }

    public async Task<List<Food>> GetFoodsFromRequestList(List<string> foodList, CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested) throw new TaskCanceledException();

        return await _context.Foods.Where(food => foodList.Any(item => food.Name == item))
            .Include(prop => prop.Contents)
            .Select(food => new Food
            {
                Name = food.Name,
                Description = food.Description,
                FoodGroup = food.FoodGroup,
                Contents = food.Contents.Select(cont => new Content
                {
                    OrigContent = cont.OrigContent,
                    SourceType = cont.SourceType,
                    StandardContent = cont.StandardContent,
                    OrigSourceName = cont.OrigSourceName,
                    OrigUnit = cont.OrigUnit
                }).ToList()
            }).ToListAsync(cancellationToken);
    }
}