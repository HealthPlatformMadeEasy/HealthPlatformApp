package com.api.server.model.contracts;

import lombok.Builder;
import lombok.Data;
import lombok.ToString;

@Data
@Builder
@ToString
public class UserDTO {
    private long id;
    private String name;
    private String email;
}
