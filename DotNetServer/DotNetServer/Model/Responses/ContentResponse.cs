using DotNetServer.Entities;

namespace DotNetServer.Model.Responses;

public record ContentResponse(
    int SourceId,
    string? SourceType,
    string? OrigUnit)
{
    public decimal? OrigContent { get; set; }
    public decimal? StandardContent { get; set; }

    public string SourceName { get; set; } = null!;

    public Nutrient? Nutrient { get; set; }

    public Compound? Compound { get; set; }
}