import axios from "axios";
import {UserIdResponse, UserRequest} from "../../types";


export async function CreateUser(user: UserRequest) {
    const {data} = await axios.post('https://localhost:7247/v1/api/users', user);
    return data;
}

export async function GetUserId(user: UserRequest): Promise<UserIdResponse> {
    const {data} = await axios.get('https://localhost:7247/v1/api/users/get-user-id', {
        params: {
            name: user.name,
            password: user.password,
            email: user.email
        }
    });
    return data;
}