import axios from "axios";
import {UserIdResponse, UserRequest} from "../../Model";

export async function CreateUser(user: UserRequest): Promise<UserIdResponse> {
    return await axios
        .post(`${import.meta.env.VITE_BASE_URL}/v1/api/users`, user)
        .then((response) => response.data);
}

export async function GetUserId(user: UserRequest): Promise<UserIdResponse> {
    return await axios
        .get(`${import.meta.env.VITE_BASE_URL}/v1/api/users/get-user-id`, {
      params: {
        name: user.name,
        password: user.password,
        email: user.email,
      },
        })
        .then((response) => response.data);
}
