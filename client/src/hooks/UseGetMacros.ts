import { useQuery } from "@tanstack/react-query";
import { GetMacros } from "../FetchFunctions/Axios";

export function useGetMacros(userId: string | undefined) {
  return useQuery(["meal-macros-data"], () => GetMacros(userId), {
    retry: false,
  });
}
