import { UserRequest } from "../Model";
import { useQuery } from "@tanstack/react-query";
import { GetUserId } from "../FetchFunctions/Axios";

export function useLogin(user: UserRequest) {
  return useQuery(["user-id"], () => GetUserId(user), {
    enabled: false,
    retry: false,
  });
}
