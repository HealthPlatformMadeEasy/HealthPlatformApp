import axios from "axios";
import { UserIdResponse, UserRequest } from "../../Model";

export async function CreateUser(user: UserRequest) {
  const { data } = await axios.post(
    "https://meal-diary.azurewebsites.net/v1/api/users",
    user,
  );
  return data;
}

export async function GetUserId(user: UserRequest): Promise<UserIdResponse> {
  const { data } = await axios.get(
    "https://meal-diary.azurewebsites.net/v1/api/users/get-user-id",
    {
      params: {
        name: user.name,
        password: user.password,
        email: user.email,
      },
    },
  );
  return data;
}
