export interface User {
    id: number;
    username: string;
    email: string;
    createdAt: string;
}
export interface AuthResponse {
    token: string;
    user: User;
}

export interface AuthRequest {
    email: string;
    password: string;
    user?: User;
}

const API_URL = "https://localhost:7289/Users";

export const login = async (data: AuthRequest): Promise<AuthResponse> => {
    const response = await fetch(`${API_URL}/login`, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(data),
    });

    if (!response.ok) {
        throw new Error("Wrong email or password.");
    }

    return response.json();
};

export const register = async (data: AuthRequest): Promise<AuthResponse> => {
    const response = await fetch(`${API_URL}/register`, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(data),
    });

    if (!response.ok) {
        throw new Error("Email already used.");
    }

    return response.json();
};
