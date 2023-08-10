namespace DotNetServer.Modules.NutrientModule.Model.DTO;

public record EnergyAndMacros(
    DateTime CreatedAt,
    double? KilokalorierKcal,
    double? Fett,
    double? Karbohydrat,
    double? Protein
);