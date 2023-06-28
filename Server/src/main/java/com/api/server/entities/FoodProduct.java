package com.api.server.entities;

import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import lombok.*;

@Getter
@Setter
@NoArgsConstructor
@AllArgsConstructor
@Builder
@Entity
public class FoodProduct {
    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    private long id;
    private String  productCategory;
    private String productName;
    private  String  per100g;
    private String productCalories;


}
