namespace DotNetServer.Modules.FoodModule.Model.Responses;

public record ContentResponse(
    string? SourceType,
    string? OrigUnit,
    string? OrigSourceName)
{
    public decimal? OrigContent { get; set; }
    public decimal? StandardContent { get; set; }
}