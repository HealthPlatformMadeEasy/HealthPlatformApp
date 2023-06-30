package com.api.server.services;

import com.api.server.model.request.CaloricCalculationRequest;
import com.api.server.model.response.CaloricResponse;
import com.api.server.model.response.FoodProductResponse;

import java.util.List;

public interface FoodProductService {
    List<FoodProductResponse> GetAllFood();

    CaloricResponse GetFood(CaloricCalculationRequest request);
}
