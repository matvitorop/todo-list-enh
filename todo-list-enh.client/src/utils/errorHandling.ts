import axios from 'axios';

const errorMessages: Record<number, string> = {
    400: "Некоректний запит.",
    401: "Неавторизований доступ.",
    403: "У вас недостатньо прав.",
    404: "Ресурс не знайдено.",
    500: "Внутрішня помилка сервера.",
};

export const handleApiError = (error: unknown) => {
    if (axios.isAxiosError(error) && error.response) {
        return errorMessages[error.response.status] || "Сталася невідома помилка.";
    }
    return "Помилка мережі або сервер недоступний.";
};