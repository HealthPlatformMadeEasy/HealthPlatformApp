using DotNetServer.Entities;
using DotNetServer.Model.Responses;
using Riok.Mapperly.Abstractions;

namespace DotNetServer.Mapping;

[Mapper]
public static partial class ContentMapper
{
    public static partial List<ContentResponse> ListContentToContentResponse(List<Content> content);
}