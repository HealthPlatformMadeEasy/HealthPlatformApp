// using DotNetServer.Core.Context;
// using DotNetServer.Modules.FoodModule.Model.Requests;
// using DotNetServer.Modules.FoodModule.Repositories;
// using DotNetServer.Modules.FoodModule.Services;
// using Microsoft.EntityFrameworkCore;
// using Xunit.Abstractions;
//
// namespace Tests.Services;
//
// public class FoodServiceTest
// {
//     private static readonly DbContextOptions<FoodbContext> Options = new DbContextOptionsBuilder<FoodbContext>()
//         .UseMySQL("Server=localhost;Port=3306;Database=foodb;Uid=foodb;Pwd=password;")
//         .Options;
//
//     private static readonly FoodbContext Context = new(Options);
//
//     private static readonly FoodRepository FoodRepository = new(Context);
//
//     private static readonly CancellationTokenSource _tokenSource = new();
//
//     private readonly FoodService _foodService = new(FoodRepository, _tokenSource.Token);
//
//     private readonly ITestOutputHelper _testOutputHelper;
//
//     public FoodServiceTest(ITestOutputHelper testOutputHelper)
//     {
//         _testOutputHelper = testOutputHelper;
//         _tokenSource.CancelAfter(10000);
//     }
//
//     [Fact]
//     public async void ReturnListContentTest()
//     {
//         var result = await _foodService.GetResultOfListFood(new List<FoodRequest>
//         {
//             new("Kiwi", 100),
//             new("Angelica", 100)
//         });
//
//         Assert.Equal(3, result.Count);
//     }
// }

