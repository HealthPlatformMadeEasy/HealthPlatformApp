package com.api.server.repositories;

import com.api.server.entities.Food;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.data.jpa.domain.Specification;

import java.util.List;
import java.util.Optional;

import static com.api.server.repositories.specifications.FoodSpecifications.hasFoodContent;

@SpringBootTest
class FoodRepositoryTest {

    @Autowired
    FoodRepository foodRepository;


    @Test
    void findFoodByName() {
        Optional<Food> food = foodRepository.findById(4);

        System.out.println(food.get().getName());
    }

    @Test
    void findFoodByNameSpecification() {
        Food food = foodRepository.findFoodByName("Kiwi");

        System.out.println(food.getId());
    }

    @Test
    void findFoodSpecificationMethod() {
        Specification<Food> specification = hasFoodContent("Kiwi");

        List<Food> response = foodRepository.findAll(specification);
        Food food = response.get(0);

        System.out.println(response.get(0).getContents().size());
    }
}