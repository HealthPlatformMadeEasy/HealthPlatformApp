using DotNetServer.Context;
using DotNetServer.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit.Abstractions;

namespace Tests.Repositories;

public class FoodRepositoryTest
{
    private static readonly DbContextOptions<FoodbContext> Options = new DbContextOptionsBuilder<FoodbContext>()
        .UseMySQL("Server=localhost;Port=3306;Database=foodb;Uid=foodb;Pwd=password;")
        .Options;

    private static readonly FoodbContext Context = new(Options);

    private readonly FoodRepository _foodRepository = new(Context);
    private readonly ITestOutputHelper _testOutputHelper;

    public FoodRepositoryTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void InputListGiveListResult()
    {
        var result = _foodRepository.GetFoodsFromRequestList(new List<string> { "Angelica", "Kiwi" });

        Assert.Equal(2, result.Count);

        Assert.Equal(2, result[0].Contents.Count);
        Assert.Equal(375, result[1].Contents.Count);

        result.ForEach(item => _testOutputHelper
            .WriteLine(item.Name + " " + item.Id + " " + item.Contents.Count));
    }
}