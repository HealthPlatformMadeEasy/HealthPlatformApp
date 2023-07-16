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
            .Include(prop => prop.Contents).ToList();
    }
}