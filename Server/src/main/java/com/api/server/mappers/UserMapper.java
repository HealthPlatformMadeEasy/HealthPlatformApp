package com.api.server.mappers;

import com.api.server.entities.AppUser;
import com.api.server.model.UserDTO;
import org.mapstruct.Mapper;

@Mapper
public interface UserMapper {

    AppUser userDtoToUser(UserDTO userDTO);

    UserDTO userToUserDto(AppUser user);
}
