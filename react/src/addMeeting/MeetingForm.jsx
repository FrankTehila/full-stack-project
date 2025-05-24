import React from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import './MeetingForm.css'; // Import the CSS file
import { Navigate } from 'react-router-dom';

const MeetingForm = () => {
    const handleSubmit = (e) => {
        e.preventDefault();
        // API call to add a meeting
    };

    const handleBackToMenu = () => {

    };

    return (
        <>
            <div className="container d-flex justify-content-center align-items-center vh-100">
                <div className="card p-4 shadow" style={{ width: '400px', marginTop: '70px' }}> {/* הוסף margin-top */}
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
                </div>
                <button className="circle-button" onClick={handleBackToMenu}>
                    <div className="arrow"></div>
                </button>
            </div>
        </>
    );
}

export default MeetingForm;
