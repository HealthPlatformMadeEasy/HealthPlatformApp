import { UserRequest } from "../Model";
import { useQuery } from "@tanstack/react-query";
import { CreateUser } from "../FetchFunctions/Axios";

export function useSignUp(user: UserRequest) {
  return useQuery(["user-id"], () => CreateUser(user), {
    enabled: false,
    retry: false,
  });
}
