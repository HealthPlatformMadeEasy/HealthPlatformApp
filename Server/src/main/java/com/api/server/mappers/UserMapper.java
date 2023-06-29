package com.api.server.mappers;

import com.api.server.entities.AppUser;
import com.api.server.model.UserDTO;
import org.mapstruct.Mapper;

@Mapper
public interface UserMapper {
    UserDTO userToUserDto(AppUser user);
}
