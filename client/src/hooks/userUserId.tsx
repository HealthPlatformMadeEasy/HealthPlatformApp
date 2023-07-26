import React, {createContext, ReactNode, useContext, useState} from 'react';
import {UserIdResponse} from "../types";

interface UserIdContextType {
    userId: UserIdResponse | null;
    setUserId: React.Dispatch<React.SetStateAction<UserIdResponse | null>>;
}

interface MyComponentProps {
    children: ReactNode;
}

const UserIdContext = createContext<UserIdContextType | undefined>(undefined);

export const UserIdProvider: React.FC<MyComponentProps> = ({children}) => {
    const [userId, setUserId] = useState<UserIdResponse | null>(null);

    return (
        <UserIdContext.Provider value={{userId, setUserId}}>
            {children}
        </UserIdContext.Provider>
    );
};

export const useUserId = (): UserIdContextType => {
    const context = useContext(UserIdContext);

    if (!context) {
        throw new Error('useUserId must be used within a UserIdProvider');
    }

    return context;
};
