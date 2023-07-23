namespace DotNetServer.UserContentModule.Model.Requests;

public record UserContentRequest(
    string SourceType,
    string OrigUnit,
    string? OrigSourceName,
    decimal? OrigContent,
    decimal? StandardContent
)
{
    public DateTime CreatedAt { get; init; } = DateTime.Now;
}