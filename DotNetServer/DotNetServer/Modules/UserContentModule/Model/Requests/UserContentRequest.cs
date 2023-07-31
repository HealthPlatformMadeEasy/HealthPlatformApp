namespace DotNetServer.Modules.UserContentModule.Model.Requests;

public record UserContentRequest(
    string? SourceType,
    string? OrigUnit,
    string? OrigSourceName,
    decimal? OrigContent,
    decimal? StandardContent,
    Guid UserId
)
{
    public Guid Id { get; init; } = Guid.NewGuid();

    public DateTime CreatedAt { get; init; } = DateTime.Now;
}