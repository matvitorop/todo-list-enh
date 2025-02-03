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
    username?: string;
    email: string;
    password: string;
    user?: User;
}
