using DotNetServer.Core.Context;
using DotNetServer.Modules.UserContentModule.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit.Abstractions;

namespace Tests.Repositories;

public class UserContentRepositoryTest
{
    private static readonly DbContextOptions<FoodbContext> Options = new DbContextOptionsBuilder<FoodbContext>()
        .UseMySQL("Server=localhost;Port=3306;Database=foodb;Uid=foodb;Pwd=password;")
        .Options;

    private static readonly FoodbContext Context = new(Options);
    private readonly ITestOutputHelper _testOutputHelper;

    private readonly UserContentRepository _userContentRepository = new(Context);

    public UserContentRepositoryTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public async void GetListMacrosAndEnergyTest()
    {
        var result =
            await _userContentRepository.GetMacrosAndEnergyAsync(new Guid("1202295b-3ce4-405f-9319-b1598c0df3a2"));

        Assert.Equal(2, result.Proteins.Count);
    }
}