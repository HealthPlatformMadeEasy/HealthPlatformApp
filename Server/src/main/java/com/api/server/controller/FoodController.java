package com.api.server.controller;

import com.api.server.entities.Content;
import com.api.server.entities.Food;
import com.api.server.model.request.CaloricCalculationRequest;
import com.api.server.repositories.FoodRepository;
import jakarta.validation.constraints.NotNull;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.jpa.domain.Specification;
import org.springframework.web.bind.annotation.*;

import java.util.List;

import static com.api.server.repositories.specifications.FoodSpecifications.hasFoodContent;

@CrossOrigin(origins = "http://localhost:5173")
@RestController
@RequestMapping("/v1/api/foods/")
public class FoodController {
    private final FoodRepository foodRepository;

    @Autowired
    public FoodController(FoodRepository foodRepository) {
        this.foodRepository = foodRepository;
    }

    @PostMapping
    public List<Food> getFood(@RequestBody @NotNull CaloricCalculationRequest request) {
        Specification<Food> specification = hasFoodContent(request.food());
        return foodRepository.findAll(specification);

    }
}
