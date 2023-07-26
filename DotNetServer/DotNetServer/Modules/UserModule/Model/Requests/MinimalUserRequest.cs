namespace DotNetServer.Modules.UserModule.Model.Requests;

public record MinimalUserRequest(string Name, string Email, string Password);