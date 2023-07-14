package com.api.server.repositories;

import com.api.server.entities.Food;
import org.springframework.data.jpa.domain.Specification;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.JpaSpecificationExecutor;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public interface FoodRepository extends JpaRepository<Food, Integer> , JpaSpecificationExecutor<Food> {
    Food findFoodByName(String name);

    @Query("SELECT f FROM Food f JOIN f.contents c WHERE f.name = :foodName")
    List<Food> findByNameAndContentsIsNotEmpty(String foodName);
}
