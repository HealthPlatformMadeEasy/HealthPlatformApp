package com.api.server.services;

import com.api.server.model.CaloricCalculationRequest;
import com.api.server.model.CaloricResponse;
import com.api.server.model.FoodProductResponse;

import java.util.List;

public interface FoodProductService {
    List<FoodProductResponse> GetAllFood();

    CaloricResponse GetFood(CaloricCalculationRequest request);
}
