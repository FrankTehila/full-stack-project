import React, { useState } from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import './MeetingForm.css';
import axios from 'axios';
import { useSelector } from 'react-redux';
import { Navigate } from 'react-router-dom';

const MeetingForm = () => {
    const userKind = useSelector((state) => state.proxy.userKind);
    const [errorMessage, setErrorMessage] = useState('');

    const handleSubmit = async (e) => {
        e.preventDefault();

        const formData = new FormData(e.target); // אוסף את הנתונים מהטופס
        const meetingData = {
            date: formData.get('date'),
            time: formData.get('time'),
            duration: formData.get('duration'),
            isProjector: formData.get('projector') === 'on', // המרת תיבת סימון לערך בוליאני
            isBoard: formData.get('board') === 'on', // המרת תיבת סימון לערך בוליאני
            leaderId: 1 // יש להחליף במזהה המנהיג המתאים
        };

        const response = await axios.post('https://localhost:7065/api/meeting/add', meetingData);
        setErrorMessage(response.data);
    };



    const handleBackToMenu = () => {

    };

    return (
        <>
        {userKind != 0 &&
            <div className="container d-flex justify-content-center align-items-center vh-100">
                <div className="card p-4 shadow" style={{ width: '400px', marginTop: '20px' }}> {/* הוסף margin-top */}
                    <h2 className="text-center mb-4 gradient-text">Schedule a Meeting</h2>
                    <form onSubmit={handleSubmit}>
                        <div className="mb-3">
                            <label htmlFor="date" className="form-label">Date:</label>
                            <input
                                type="date"
                                id="date"
                                name="date"
                                className="form-control"
                                required
                            />
                        </div>
                        <div className="mb-3">
                            <label htmlFor="time" className="form-label">Time:</label>
                            <input
                                type="time"
                                id="time"
                                name="time"
                                className="form-control"
                                required
                            />
                        </div>
                        <div className="mb-3">
                            <label htmlFor="duration" className="form-label">Duration (Hours):</label>
                            <input
                                type="number"
                                id="duration"
                                name="duration"
                                className="form-control"
                                required
                            />
                        </div>
                        <div className="mb-3 form-check">
                            <input
                                type="checkbox"
                                id="projector"
                                name="projector"
                                className="form-check-input"
                            />
                            <label htmlFor="projector" className="form-check-label">Projector?</label>
                        </div>
                        <div className="mb-3 form-check">
                            <input
                                type="checkbox"
                                id="board"
                                name="board"
                                className="form-check-input"
                            />
                            <label htmlFor="board" className="form-check-label">Board?</label>
                        </div>
                        <button type="submit" className="btn btn-primary w-100">Schedule Meeting</button>
                    </form>
                    <br />
                    <p>{errorMessage}</p>
                </div>
                <button className="circle-button" onClick={handleBackToMenu}>
                    <div className="arrow"></div>
                </button>
            </div>}
            {userKind == 0 && <h1>You do not have permission to add a meeting.</h1>}

        </>
    );
}

export default MeetingForm;
