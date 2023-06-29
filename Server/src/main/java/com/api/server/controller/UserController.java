package com.api.server.controller;

import com.api.server.mappers.UserMapper;
import com.api.server.model.UserDTO;
import com.api.server.services.UserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

@RestController
@RequestMapping("/v1/api/user/")
public class UserController {

    private final UserService userService;
    private final UserMapper userMapper;

    @Autowired
    public UserController(UserService userService, UserMapper userMapper) {

        this.userService = userService;
        this.userMapper = userMapper;
    }

    @GetMapping()
    public List<UserDTO> GetHelp() {
        var result = userService.getAllUsers();
        var response = result.stream().map(userMapper::userToUserDto).toList();

        return response;
    }
}
