import api from './api/axiosConfig';

// דוגמאות לשימוש ב-API עם טוקן אוטומטי

export const addMeeting = async (meetingData) => {
    try {
        const response = await api.post('/Meeting/Add', meetingData);
        return response.data;
    } catch (error) {
        console.error('Error adding meeting:', error);
        throw error;
    }
};

export const deleteMeeting = async (meetingId) => {
    try {
        const response = await api.delete('/Meeting', { data: meetingId.toString() });
        return response.data;
    } catch (error) {
        console.error('Error deleting meeting:', error);
        throw error;
    }
};

export const getMeetings = async () => {
    try {
        const response = await api.get('/Meeting');
        return response.data;
    } catch (error) {
        console.error('Error fetching meetings:', error);
        throw error;
    }
};

// ניתן להוסיף פונקציות נוספות כאן...