package com.api.server.services;

import com.api.server.entities.FoodProduct;
import com.api.server.mappers.FoodProductMapper;
import com.api.server.model.request.CaloricCalculationRequest;
import com.api.server.model.response.CaloricResponse;
import com.api.server.model.response.FoodProductResponse;
import com.api.server.repositories.FoodProductRepository;
import org.jetbrains.annotations.NotNull;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class FoodProductServiceImpl implements FoodProductService {
    private final FoodProductRepository foodProductRepository;
    private final FoodProductMapper mapper;

    public FoodProductServiceImpl(FoodProductRepository foodProductRepository, FoodProductMapper mapper) {
        this.foodProductRepository = foodProductRepository;
        this.mapper = mapper;
    }

    @Override
    public List<FoodProductResponse> GetAllFood() {
        return mapper.listFoodProductToFoodProductsDto(foodProductRepository.findAll());
    }

    @Override
    public CaloricResponse GetFood(@NotNull CaloricCalculationRequest request) {
        FoodProduct food = foodProductRepository.findFoodProductByProductNameEquals(request.food());
        long cal = Long.parseLong(food.getProductCalories());

        return new CaloricResponse(cal * request.quantity());
    }

}
