import { create } from "zustand";
import { User } from "../Interfaces/UserInterfaces";

interface UserState {
    user: User | null;
    setUser: (user: User | null) => void;
    logout: () => void;
}

export const useUserStore = create<UserState>((set) => ({
    user: null,
    setUser: (user) => set({ user }),
    logout: () => {
        localStorage.removeItem("token");
        localStorage.removeItem("user");
        set({ user: null });
    },
}));