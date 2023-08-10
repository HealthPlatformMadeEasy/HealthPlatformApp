import { createContext, useContext } from "react";
import { UserIdContextType } from "./userUserId.tsx";

export const UserIdContext = createContext<UserIdContextType | undefined>(
  undefined,
);

export const useUserId = (): UserIdContextType => {
  const context = useContext(UserIdContext);

  if (!context) {
    throw new Error("useUserId must be used within a UserIdProvider");
  }

  return context;
};
