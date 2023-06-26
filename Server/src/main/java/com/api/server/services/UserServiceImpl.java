package com.api.server.services;

import com.api.server.entities.User;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.List;

@Service
public class UserServiceImpl implements UserService {
    @Override
    public List<User> getAllUsers() {
        List<User> usersList = new ArrayList<User>();
        usersList.add(new User(1,"a","as","as"));
        usersList.add(new User(2,"b","as","as"));
        usersList.add(new User(3,"c","as","as"));
        usersList.add(new User(4,"d","as","as"));

        return usersList;
    }
}
