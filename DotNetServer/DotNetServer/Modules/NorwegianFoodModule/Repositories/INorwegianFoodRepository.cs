using DotNetServer.Modules.NorwegianFoodModule.Entities;

namespace DotNetServer.Modules.NorwegianFoodModule.Repositories;

public interface INorwegianFoodRepository
{
    public NorwegianFood? GetNorwegianFoodById(Guid id);

    Task<NorwegianFood?> GetNorwegianFoodByName(string food, CancellationToken cancellationToken);

    Task<List<NorwegianFood>?> GetNorwegianFoodsByNameList(List<string> foodList, CancellationToken cancellationToken);
}