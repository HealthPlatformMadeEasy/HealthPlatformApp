using DotNetServer.Modules.NutrientModule.Model.DTO;

namespace DotNetServer.Modules.NutrientModule.Model.Responses;

public class EnergyAndMacroResponse
{
    public List<EnergyDto> EnergyDtos { get; set; } = null!;

    public List<CarbDto> CarbDtos { get; set; } = null!;

    public List<FatDto> FatDtos { get; set; } = null!;

    public List<ProteinDto> ProteinDtos { get; set; } = null!;

    public void SetEnergyAndMacrosResponseFromList(List<EnergyAndMacros>? input)
    {
        EnergyDtos = new List<EnergyDto>();
        CarbDtos = new List<CarbDto>();
        FatDtos = new List<FatDto>();
        ProteinDtos = new List<ProteinDto>();

        input.ForEach(row =>
        {
            EnergyDtos.Add(new EnergyDto(row.CreatedAt, row.KilokalorierKcal));
            CarbDtos.Add(new CarbDto(row.CreatedAt, row.Karbohydrat));
            FatDtos.Add(new FatDto(row.CreatedAt, row.Fett));
            ProteinDtos.Add(new ProteinDto(row.CreatedAt, row.Protein));
        });

        EnergyDtos = EnergyDtos.OrderBy(row => row.CreatedAt).ToList();
        CarbDtos = CarbDtos.OrderBy(row => row.CreatedAt).ToList();
        FatDtos = FatDtos.OrderBy(row => row.CreatedAt).ToList();
        ProteinDtos = ProteinDtos.OrderBy(row => row.CreatedAt).ToList();
    }
}