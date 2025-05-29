import React from 'react';
import './Manager.css'; // קובץ CSS לעיצוב

const Manager = () => {
    const handleAddEmployee = () => {
        // לוגיקה להוספת עובד
    };

    const handleDeleteEmployee = () => {
        // לוגיקה למחיקת עובד
    };

    const handleUpdateEmployee = () => {
        // לוגיקה לעדכון פרטי עובד
    };

    const handleAddRoom = () => {
        // לוגיקה להוספת חדר
    };

    const handleDeleteRoom = () => {
        // לוגיקה למחיקת חדר
    };

    const handleUpdateRoom = () => {
        // לוגיקה לעדכון פרטי חדר
    };

    return (
        <div className="manager-container">
            <button className="manager-button" onClick={handleAddEmployee}>הוסף עובד</button>
            <br />
            <button className="manager-button" onClick={handleDeleteEmployee}>מחק עובד</button>
            <br />
            <button className="manager-button" onClick={handleUpdateEmployee}>עדכן פרטי עובד</button>
            <br />
            <button className="manager-button" onClick={handleAddRoom}>הוסף חדר</button>
            <br />
            <button className="manager-button" onClick={handleDeleteRoom}>מחק חדר</button>
            <br />
            <button className="manager-button" onClick={handleUpdateRoom}>עדכן פרטי חדר</button>
        </div>
    );
};

export default Manager;
