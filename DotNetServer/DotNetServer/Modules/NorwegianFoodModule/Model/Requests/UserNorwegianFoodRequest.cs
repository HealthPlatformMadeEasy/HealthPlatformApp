namespace DotNetServer.Modules.NorwegianFoodModule.Model.Requests;

public record UserNorwegianFoodRequest(
    Guid UserId,
    List<NorwegianFoodRequest> Requests
);