namespace DotNetServer.Model.Responses;

public record ContentResponse(
    int SourceId,
    string? SourceType,
    decimal? OrigContent,
    string? OrigUnit,
    decimal StandardContent);