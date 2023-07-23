namespace DotNetServer.UserModule.Model.Responses;

public record UserResponse(
    Guid Id,
    string Name,
    string Email,
    DateTime CreatedAt
);