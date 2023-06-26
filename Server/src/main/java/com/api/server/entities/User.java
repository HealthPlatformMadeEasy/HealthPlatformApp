package com.api.server.entities;

//import jakarta.persistence.Entity;
import lombok.*;

@Setter
@Getter
@AllArgsConstructor
@NoArgsConstructor
@Builder
//@Entity
public class User {
    private int id;
    private String name;
    private String email;
    private String password;

}
