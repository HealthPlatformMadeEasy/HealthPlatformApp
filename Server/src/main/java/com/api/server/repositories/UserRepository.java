package com.api.server.repositories;

import com.api.server.entities.AppUser;
import org.springframework.data.jpa.repository.JpaRepository;


public interface UserRepository extends JpaRepository<AppUser, Long> {
//test
}
