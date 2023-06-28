package com.api.server.services;

import com.api.server.entities.AppUser;

import java.util.List;


public interface UserService {

    List<AppUser> getAllUsers();

}