package com.api.server.mappers;

import com.api.server.entities.User;
import com.api.server.model.UserDTO;
import org.mapstruct.Mapper;

@Mapper

public interface UserMapper {

    User userDtoToUser(UserDTO userDTO) ;
    UserDTO userToUserDto(User user) ;
}
