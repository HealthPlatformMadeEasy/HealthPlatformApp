﻿using DotNetServer.Model.Requests;
using DotNetServer.Model.Responses;

namespace DotNetServer.Services;

public interface IFoodService
{
    FoodResponse GetFood(FoodRequest request);

    List<ContentResponse> GetResultOfListFood(List<FoodRequest> requests);
}