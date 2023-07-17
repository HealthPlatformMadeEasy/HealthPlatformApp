using DotNetServer.Context;
using DotNetServer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotNetServer.Repositories;

public class FoodRepository : IFoodRepository
{
    private readonly FoodbContext _context;

    public FoodRepository(FoodbContext context)
    {
        _context = context;
    }

    public List<Food> GetFood(string foodName)
    {
        return _context.Foods.Where(food => food.Name == foodName)
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
            }).ToList();
    }
}