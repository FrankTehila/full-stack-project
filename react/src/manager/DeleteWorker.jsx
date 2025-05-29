import React, { useState } from 'react';

const DeleteWorker = () => {
    const [workerId, setWorkerId] = useState('');
    const [message, setMessage] = useState('');

    const handleDelete = async (e) => {
        e.preventDefault();
        setMessage('');
        if (!workerId || isNaN(workerId)) {
            setMessage('אנא הזן מזהה עובד חוקי (מספר שלם)');
            return;
        }
        try {
            const response = await fetch(`/api/workers/${workerId}`, {
                method: 'DELETE',
            });
            if (response.ok) {
                setMessage('העובד נמחק בהצלחה');
                setWorkerId('');
            } else if (response.status === 404) {
                setMessage('העובד לא נמצא');
            } else {
                setMessage('אירעה שגיאה במחיקת העובד');
            }
        } catch (error) {
            setMessage('שגיאת רשת');
        }
    };

    return (
        <form onSubmit={handleDelete} style={{ maxWidth: 300, margin: 'auto' }}>
            <h2>מחיקת עובד</h2>
            <label>
                מזהה עובד (ID):
                <input
                    type="number"
                    value={workerId}
                    onChange={(e) => setWorkerId(e.target.value)}
                    required
                    min="1"
                />
            </label>
            <button type="submit">מחק עובד</button>
            {message && <div style={{ marginTop: 10 }}>{message}</div>}
        </form>
    );
};

export default DeleteWorker;