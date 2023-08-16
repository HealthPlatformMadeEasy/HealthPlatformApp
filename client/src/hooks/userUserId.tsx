import React, { ReactNode, useState } from "react";
import { UserIdResponse } from "../Model";
import { UserIdContext } from ".";

export interface UserIdContextType {
  userId: UserIdResponse | null;
  setUserId: React.Dispatch<React.SetStateAction<UserIdResponse | null>>;
}

interface MyComponentProps {
  children: ReactNode;
}

export const UserIdProvider: React.FC<MyComponentProps> = ({ children }) => {
  const [userId, setUserId] = useState<UserIdResponse | null>(null);

  return (
    <UserIdContext.Provider value={{ userId, setUserId }}>
      {children}
    </UserIdContext.Provider>
  );
};
