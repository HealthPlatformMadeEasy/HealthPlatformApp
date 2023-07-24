namespace DotNetServer.Modules.UserContentModule.Model.Responses;

public record UserContentResponse(
    string SourceType,
    string OrigUnit,
    string? OrigSourceName,
    decimal? OrigContent,
    decimal? StandardContent,
    DateTime CreatedAt,
    Guid UserId
);