import { createContext, useState, useEffect } from "react";

export const AuthContext = createContext();

export function AuthProvider({ children }) {
    const [username, setUsername] = useState('');

    useEffect(() => {
        const storedUser = localStorage.getItem("username");
        if (storedUser) setUsername(storedUser);
    }, []);

    const login = (name) => {
        localStorage.setItem("username", name);
        setUsername(name);
    };

    const logout = () => {
        localStorage.removeItem("username");
        localStorage.removeItem("token");
        setUsername('');
    };

    return (
        <AuthContext.Provider value={{ username, login, logout }}>
            {children}
        </AuthContext.Provider>
    );
}
