using DotNetServer.Core.Context;
using DotNetServer.Modules.FoodModule.Mapping;
using DotNetServer.Modules.FoodModule.Model.Requests;
using DotNetServer.Modules.FoodModule.Model.Responses;
using DotNetServer.Modules.FoodModule.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit.Abstractions;

namespace Tests;

public class UnitTest1
{
    private static readonly DbContextOptions<FoodbContext> Options = new DbContextOptionsBuilder<FoodbContext>()
        .UseMySQL("Server=localhost;Port=3306;Database=foodb;Uid=foodb;Pwd=password;")
        .Options;

    private static readonly FoodbContext Context = new(Options);
    private readonly FoodRepository _foodRepository = new(Context);

    private readonly ITestOutputHelper _testOutputHelper;

    public UnitTest1(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }


    [Fact]
    public void Test1()
    {
        var kiwi = Context.Foods.Where(food => food.Name == "Kiwi")
            .Include(food => food.Contents).ToList();

        Assert.Equal(375, kiwi[0].Contents.Count);
    }

    [Fact]
    public void TestMapper()
    {
        var request = new FoodRequest("Angelica", 200);
        var db = _foodRepository.GetFood(request.Food);
        var response = db.Select(food => FoodMapper.FoodToFoodResponse(food)).Single();

        _testOutputHelper.WriteLine(response.Contents.ToString());

        Assert.IsType<List<ContentResponse>>(response.Contents);

        Assert.Equal(response.Contents[0].OrigContent, 27);
    }
}