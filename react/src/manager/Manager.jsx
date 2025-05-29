import React from 'react';
import './Manager.css'; // קובץ CSS לעיצוב
import { useState } from 'react';
import AddWorker from './AddWorker';
import AddRoom from './AddRoom';
import UpdateWorker from "./UpdateWorker";
import DeleteWorker from './DeleteWorker'; 
import UpdateRoom from './UpdateRoom';


const Manager = () => {
    const [showAddWorker, setShowAddWorker] = useState(false);
    const [showAddRoom, setShowAddRoom] = useState(false);
    const [showUpdateWorker, setShowUpdareWorker] = useState(false);
    const [showDeleteWorker, setShowDeleteWorker] = useState(false);
    const [showUpdateRoom, setShowUpdateRoom] = useState(false);

    const resetAll = () => {
        setShowAddWorker(false);
        setShowAddRoom(false);
        setShowUpdareWorker(false);
        setShowDeleteWorker(false);
        setShowUpdateRoom(false);
    };

    return (
        <div className="manager-container">
            {/* <h3 className="manager-title">ניהול עובדים וחדרים</h3> */}
            {showAddWorker && <AddWorker />}
            {showAddRoom && <AddRoom />}
            {showUpdateWorker && <UpdateWorker />}
            {showDeleteWorker && <DeleteWorker />}
            {showUpdateRoom && <UpdateRoom />}
            

            <button
                className="manager-button"
                onClick={() => {
                    resetAll();
                    setShowAddWorker(true);
                }}
            >
                הוספת עובד
            </button>

            <button
                className="manager-button"
                onClick={() => {
                    resetAll();
                    setShowDeleteWorker(true);
                }}>מחק עובד</button>

            <button
                className="manager-button"
                onClick={() => {
                    resetAll();
                    setShowUpdareWorker(true);
                }}
            >
                עדכון פרטי עובד
            </button>

            <button
                className="manager-button"
                onClick={() => {
                    resetAll();
                    setShowAddRoom(true);
                }}
            >
                הוספת חדר
            </button>

            <button
                className="manager-button"
                onClick={() => {
                    resetAll();
                    setShowUpdateRoom(true);
            }}
            >עדכן פרטי חדר
            </button>
            
           
        </div>
    );

};
export default Manager;
