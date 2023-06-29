package com.api.server.controller;

import com.api.server.model.CaloricCalculationRequest;
import com.api.server.model.CaloricResponse;
import com.api.server.model.FoodProductResponse;
import com.api.server.services.FoodProductService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.List;


@RestController
@RequestMapping("/v1/api/food-product/")
public class FoodProductController {

    private final FoodProductService service;

    @Autowired
    public FoodProductController(FoodProductService service) {

        this.service = service;
    }

    @GetMapping
    public List<FoodProductResponse> getAllProducts() {
        return service.GetAllFood();
    }

    @PostMapping("search-by-food")
    public CaloricResponse getFood(@RequestBody CaloricCalculationRequest request) {

        return service.GetFood(request);
    }
}
