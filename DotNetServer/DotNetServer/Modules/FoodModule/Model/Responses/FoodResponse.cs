﻿namespace DotNetServer.Modules.FoodModule.Model.Responses;

public record FoodResponse(
    string Name,
    string? Description,
    string? FoodGroup,
    List<ContentResponse> Contents);