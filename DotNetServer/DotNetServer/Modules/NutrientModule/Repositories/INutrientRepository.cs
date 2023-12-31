﻿using DotNetServer.Modules.NutrientModule.Entities;
using DotNetServer.Modules.NutrientModule.Model.DTO;

namespace DotNetServer.Modules.NutrientModule.Repositories;

public interface INutrientRepository
{
    Task<Nutrient?> GetNutrientByIdAsync(Guid id, CancellationToken cancellationToken);

    Task AddNutrientAsync(Nutrient nutrient, CancellationToken cancellationToken);

    Task AddManyNutrientsAsync(List<Nutrient> nutrients, CancellationToken cancellationToken);

    Task DeleteNutrientAsync(Guid id, CancellationToken cancellationToken);

    Task<List<EnergyAndMacros>?> GetEnergyAndMacros(Guid userId, CancellationToken cancellationToken);
}