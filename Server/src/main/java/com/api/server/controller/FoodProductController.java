package com.api.server.controller;

import com.api.server.entities.FoodProduct;
import com.api.server.repositories.FoodProductRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;


@RestController
@RequestMapping("/api/foodProduct/")
public class FoodProductController {

    private final FoodProductRepository foodProductRepository;
    @Autowired
    public FoodProductController(FoodProductRepository foodProductRepository) {
        this.foodProductRepository = foodProductRepository;
    }

    @GetMapping
    public List<FoodProduct> getAllProducts() {
        return foodProductRepository.findAll();
    }
}
