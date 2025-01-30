import { AuthRequest, AuthResponse } from "../Interfaces/UserInterfaces"

const API_URL = "https://localhost:7289/Users";

export async function loginUser(email : string, password : string) {
    const response = await fetch(`${API_URL}/login`, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({
            username: "undefined",
            email,
            password,
            createdAt: new Date().toISOString(),
        }),
    });

    if (!response.ok) {
        throw new Error("Wrong email or password.");
    }

    return await response.json();
}

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
