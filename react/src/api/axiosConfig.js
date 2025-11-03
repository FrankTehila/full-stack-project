import axios from 'axios';

// הגדרת Base URL
const api = axios.create({
    baseURL: 'https://localhost:7065/api'
});

// Interceptor - מוסיף טוקן אוטומטית לכל בקשה
api.interceptors.request.use(
    (config) => {
        const token = localStorage.getItem('token');
        if (token) {
            config.headers.Authorization = `Bearer ${token}`;
        }
        return config;
    },
    (error) => {
        return Promise.reject(error);
    }
);

// Interceptor לתגובות - טיפול בשגיאות 401 (Unauthorized)
api.interceptors.response.use(
    (response) => response,
    (error) => {
        if (error.response && error.response.status === 401) {
            // טוקן לא תקף - מנקה ומעביר להתחברות
            localStorage.removeItem('token');
            window.location.href = '/';
        }
        return Promise.reject(error);
    }
);

export default api;
