using DotNetServer.FoodModule.Entities;
using DotNetServer.FoodModule.Model.Responses;
using Riok.Mapperly.Abstractions;

namespace DotNetServer.FoodModule.Mapping;

[Mapper]
public static partial class ContentMapper
{
    public static partial List<ContentResponse> ListContentToContentResponse(List<Content> content);
}