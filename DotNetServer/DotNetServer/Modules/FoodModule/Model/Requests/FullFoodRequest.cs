namespace DotNetServer.Modules.FoodModule.Model.Requests;

public record FullFoodRequest(Guid UserId, List<FoodRequest> FoodRequests);