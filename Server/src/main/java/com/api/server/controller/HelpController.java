package com.api.server.controller;

import com.api.server.entities.AppUser;
import com.api.server.services.UserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

@RestController
public class HelpController {

    private final UserService userService;

    @Autowired
    public HelpController(UserService userService) {

        this.userService = userService;
    }

    @GetMapping("/help")
    public List<AppUser> GetHelp() {
        return userService.getAllUsers();
    }

//    @GetMapping("/help")
//    public List<User> GetHelp() {
//        return userService.getAllUsers();
//    }
}
