namespace DotNetServer.Modules.UserContentModule.Model.Responses;

public record MacrosAndEnergyResponse(
    List<UserContentResponse> Carbs,
    List<UserContentResponse> Proteins,
    List<UserContentResponse> Fats,
    List<UserContentResponse> Energy
);