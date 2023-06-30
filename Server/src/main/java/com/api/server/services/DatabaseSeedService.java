package com.api.server.services;

import com.api.server.entities.FoodProduct;
import com.api.server.repositories.FoodProductRepository;
import com.api.server.utils.CsvUtils;
import org.springframework.context.annotation.Profile;
import org.springframework.stereotype.Service;

import java.io.IOException;
import java.io.InputStream;
import java.util.List;

@Profile("development")
@Service
public class DatabaseSeedService {


    private final FoodProductRepository foodProductRepository;

    public DatabaseSeedService(FoodProductRepository foodProductRepository) {
        this.foodProductRepository = foodProductRepository;
    }

    public void seedDatabaseFromCSVFile(InputStream stream) throws IOException {
        if (foodProductRepository.count() == 0) {
            List<FoodProduct> foodItems = CsvUtils.read(FoodProduct.class, stream);
            foodProductRepository.saveAll(foodItems);
        }
    }
}
