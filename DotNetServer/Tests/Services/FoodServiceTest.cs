using DotNetServer.Core.Context;
using DotNetServer.Modules.FoodModule.Model.Requests;
using DotNetServer.Modules.FoodModule.Repositories;
using DotNetServer.Modules.FoodModule.Services;
using Microsoft.EntityFrameworkCore;
using Xunit.Abstractions;

namespace Tests.Services;

public class FoodServiceTest
{
    private static readonly DbContextOptions<FoodbContext> Options = new DbContextOptionsBuilder<FoodbContext>()
        .UseMySQL("Server=localhost;Port=3306;Database=foodb;Uid=foodb;Pwd=password;")
        .Options;

    private static readonly FoodbContext Context = new(Options);

    private static readonly FoodRepository FoodRepository = new(Context);

    private readonly FoodService _foodService = new(FoodRepository);

    private readonly ITestOutputHelper _testOutputHelper;

    public FoodServiceTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void ReturnListContentTest()
    {
        var result = _foodService.GetResultOfListFood(new List<FoodRequest>
        {
            new("Kiwi", 100),
            new("Angelica", 100)
        });

        Assert.Equal(3, result.Count);
    }
}