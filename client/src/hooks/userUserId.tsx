import React, {createContext, ReactNode, useContext, useState} from 'react';

interface UserIdContextType {
    userId: string | null;
    setUserId: React.Dispatch<React.SetStateAction<string | null>>;
}

interface MyComponentProps {
    children: ReactNode;
}

const UserIdContext = createContext<UserIdContextType | undefined>(undefined);

export const UserIdProvider: React.FC<MyComponentProps> = ({children}) => {
    const [userId, setUserId] = useState<string | null>(null);

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
