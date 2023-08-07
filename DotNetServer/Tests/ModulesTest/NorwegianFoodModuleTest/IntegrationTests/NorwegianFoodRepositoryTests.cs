using DotNetServer.Core.Context;
using DotNetServer.Modules.NorwegianFoodModule.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit.Abstractions;

namespace Tests.ModulesTest.NorwegianFoodModuleTest.IntegrationTests;

public class NorwegianFoodRepositoryTests
{
    private static readonly DbContextOptions<NorwegianFoodDbContext> Options =
        new DbContextOptionsBuilder<NorwegianFoodDbContext>()
            .UseMySQL("Server=localhost;Port=3306;Database=fooddb;Uid=foodDb;Pwd=password;")
            .Options;

    private static readonly NorwegianFoodDbContext Context = new(Options);
    private readonly CancellationTokenSource _cancellationTokenSource = new();

    private readonly List<string> _foods = new() { "Ål, røkt", "Karamell", "Hummus" };

    private readonly NorwegianFoodRepository _norwegianFoodRepository = new(Context);
    private readonly ITestOutputHelper _testOutputHelper;


    public NorwegianFoodRepositoryTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
        _cancellationTokenSource.CancelAfter(10000);
    }

    [Fact]
    public async void GetResponseFromNorwegianFoodsRequestTest()
    {
        var result = await
            _norwegianFoodRepository.GetNorwegianFoodsByNameList(_foods, _cancellationTokenSource.Token);

        Assert.Equal(3, result!.Count);
        Assert.Equal(new Guid("0174a46c-5ca0-4f4c-b7a0-d35fd2d7685a"), result[0].Id);
    }
}