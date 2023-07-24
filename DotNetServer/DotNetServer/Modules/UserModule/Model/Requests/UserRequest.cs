namespace DotNetServer.Modules.UserModule.Model.Requests;

public record UserRequest(
    string Name,
    string Password,
    string Email
)
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public DateTime CreatedAt { get; init; } = DateTime.Now;
}