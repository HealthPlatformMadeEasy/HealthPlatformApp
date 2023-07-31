using DotNetServer.Modules.UserContentModule.Entities;

namespace DotNetServer.Modules.UserContentModule.Model.DTO;

public class MacrosAndEnergy
{
    public List<UserContent> Carbs { get; set; } = null!;
    public List<UserContent> Proteins { get; set; } = null!;
    public List<UserContent> Fats { get; set; } = null!;
    public List<UserContent> Energy { get; set; } = null!;
}