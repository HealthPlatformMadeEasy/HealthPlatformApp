namespace DotNetServer.Model.Requests;

public record UserRequest(
    string Name,
    string Password,
    string Email
)
{
    public DateTime CreatedAt { get; init; } = DateTime.Now;
}