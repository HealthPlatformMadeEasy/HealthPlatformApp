package com.api.server.repositories.specifications;

import com.api.server.entities.Content;
import com.api.server.entities.Food;
import jakarta.persistence.criteria.Join;
import org.jetbrains.annotations.Contract;
import org.jetbrains.annotations.NotNull;
import org.springframework.data.jpa.domain.Specification;



public class FoodSpecifications {
    @Contract(pure = true)
    public static @NotNull Specification<Food> hasFoodContent(String name) {
        return (root, query, criteriaBuilder) -> {
            Join<Food, Content> foodContentJoin = root.join("contents");
            return criteriaBuilder.equal(root.<String>get("name"),name);
        };
    }

}
