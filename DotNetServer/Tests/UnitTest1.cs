using DotNetServer.Context;
using Microsoft.EntityFrameworkCore;

namespace Tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var context = new FoodbContext();
        
        var kiwi = context.Foods.Where(food => food.Name == "Kiwi")
            .Include(food => food.Contents).ToList();
        
        Assert.Equal(375, kiwi[0].Contents.Count);
    }
}