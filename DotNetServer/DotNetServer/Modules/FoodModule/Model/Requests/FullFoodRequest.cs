namespace DotNetServer.Modules.FoodModule.Model.Requests;

public record FullFoodRequest(string UserId, List<FoodRequest> FoodRequests);