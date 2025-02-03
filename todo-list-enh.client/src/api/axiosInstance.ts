import axios from 'axios';
import { handleApiError } from '../utils/errorHandling';

const axiosInstance = axios.create({
    baseURL: "https://localhost:7289",
    headers: { "Content-Type": "application/json" },
});


axiosInstance.interceptors.response.use(
    (response) => response,
    (error) => {
        const errorMessage = handleApiError(error);
        return Promise.reject(new Error(errorMessage));
    }
);

export default axiosInstance;
