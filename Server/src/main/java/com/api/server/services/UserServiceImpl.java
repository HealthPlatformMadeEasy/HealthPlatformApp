package com.api.server.services;

import com.api.server.entities.AppUser;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.List;

@Service
public class UserServiceImpl implements UserService {
    @Override
    public List<AppUser> getAllUsers() {
        List<AppUser> usersList = new ArrayList<>();
        usersList.add(new AppUser(1, "a", "as", "as"));
        usersList.add(new AppUser(2, "b", "as", "as"));
        usersList.add(new AppUser(3, "c", "as", "as"));
        usersList.add(new AppUser(4, "d", "as", "as"));

        return usersList;
    }
}
