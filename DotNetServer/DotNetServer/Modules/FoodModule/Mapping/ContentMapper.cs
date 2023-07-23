using DotNetServer.Modules.FoodModule.Entities;
using DotNetServer.Modules.FoodModule.Model.Responses;
using Riok.Mapperly.Abstractions;

namespace DotNetServer.Modules.FoodModule.Mapping;

[Mapper]
public static partial class ContentMapper
{
    public static partial List<ContentResponse> ListContentToContentResponse(List<Content> content);
}