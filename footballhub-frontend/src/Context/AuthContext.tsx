import { createContext, ReactNode, useContext, useState } from "react";

type UserState = {
  googleId: string;
  imageUrl: string;
  email: string;
  name: string;
  givenName: string;
  familyName: string;
} | null;

const AuthContext = createContext<
  | {
      user: UserState;
      setUser: React.Dispatch<React.SetStateAction<UserState>>;
    }
  | undefined
>(undefined);

export const AuthProvider: React.FC<{ children: ReactNode }> = ({
  children,
}) => {
  const [user, setUser] = useState<UserState>(null);

  return (
    <AuthContext.Provider value={{ user, setUser }}>
      {children}
    </AuthContext.Provider>
  );
};

export const useAuth = () => {
  const context = useContext(AuthContext);
  if (!context) {
    throw new Error("useAuth must be used within an AuthProvider");
  }
  return context;
};
