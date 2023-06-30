package com.api.server.repositories;

import com.api.server.entities.FoodProduct;
import org.springframework.data.jpa.repository.JpaRepository;

public interface FoodProductRepository  extends JpaRepository<FoodProduct, String> {
}
