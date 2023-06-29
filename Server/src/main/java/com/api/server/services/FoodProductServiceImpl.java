package com.api.server.services;

import com.api.server.entities.FoodProduct;
import com.api.server.mappers.FoodProductMapper;
import com.api.server.model.CaloricCalculationRequest;
import com.api.server.model.CaloricResponse;
import com.api.server.model.FoodProductResponse;
import com.api.server.repositories.FoodProductRepository;
import lombok.extern.slf4j.Slf4j;
import org.springframework.stereotype.Service;

import java.util.List;

@Slf4j
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
    public CaloricResponse GetFood(CaloricCalculationRequest request) {
        log.debug(request.food());
        FoodProduct food = foodProductRepository.findFoodProductByProductNameEquals(request.food());
        long cal = Long.parseLong(food.getProductCalories());

        return new CaloricResponse(cal * request.quantity());
    }

}
