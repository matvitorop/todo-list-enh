import axios from 'axios';

const errorMessages: Record<number, string> = {
    400: "Bad reqest",
    401: "You need to authorize",
    403: "You dont have the access",
    404: "Not found",
    500: "Internal server error",
};

export const handleApiError = (error: unknown) => {
    if (axios.isAxiosError(error) && error.response) {
        return errorMessages[error.response.status] || "Unknown error happend";
    }
    return "Network error or server is inaccessible";
};