package com.api.server.services;

import com.api.server.entities.User;
import org.springframework.stereotype.Service;

import java.util.List;


public interface UserService {

    List<User> getAllUsers();

}