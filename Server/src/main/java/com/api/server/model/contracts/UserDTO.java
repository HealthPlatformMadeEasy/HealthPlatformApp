package com.api.server.model.contracts;

import jakarta.validation.constraints.Email;
import jakarta.validation.constraints.NotBlank;
import jakarta.validation.constraints.NotNull;
import jakarta.validation.constraints.Size;
import lombok.Builder;
import lombok.Data;
import lombok.ToString;

@Data
@Builder
@ToString
public class UserDTO {
    @NotNull
    @NotBlank
    @Size(min = 36, max = 36)
    private String id;

    @NotNull
    @NotBlank
    @Size( max = 50)
    private String name;

    @NotNull
    @NotBlank
    @Size( max = 70)
    @Email
    private String email;
}
