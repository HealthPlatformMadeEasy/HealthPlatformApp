using DotNetServer.Core.Context;
using DotNetServer.Modules.FoodModule.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit.Abstractions;

namespace Tests.ModulesTest.FoodModuleTest.IntegrationTests.IntegrationRepositoryTest;

public class FoodIntegrationRepositoryTest
{
    private static readonly DbContextOptions<FoodbContext> Options = new DbContextOptionsBuilder<FoodbContext>()
        .UseMySQL("Server=localhost;Port=3306;Database=foodb;Uid=foodb;Pwd=password;")
        .Options;

    private static readonly FoodbContext Context = new(Options);

    private readonly FoodRepository _foodRepository = new(Context);
    private readonly ITestOutputHelper _testOutputHelper;

    public FoodIntegrationRepositoryTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public async void InputListGiveListResult()
    {
        var token = new CancellationTokenSource();
        token.CancelAfter(10000);

        var result =
            await _foodRepository.GetFoodsFromRequestList(new List<string> { "Angelica", "Kiwi" }, token.Token);

        Assert.Equal(2, result.Count);

        Assert.Equal(2, result[0].Contents.Count);
        Assert.Equal(375, result[1].Contents.Count);

        result.ForEach(item => _testOutputHelper
            .WriteLine(item.Name + " " + item.Id + " " + item.Contents.Count));
    }

    [Fact]
    public async void NotOnDatabaseRequestTest()
    {
        var token = new CancellationTokenSource();
        token.CancelAfter(10000);

        var result = await _foodRepository.GetFoodsFromRequestList(new List<string> { "Tomato" }, token.Token);
        Assert.Equal(2, result.Count);
    }
}