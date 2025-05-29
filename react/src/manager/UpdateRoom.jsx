import React, { useState } from "react";
import axios from "axios";
import "../addMeeting/MeetingForm.css";
import 'bootstrap/dist/css/bootstrap.min.css';
const UpdateRoom = () => {
    const [roomNumber, setRoomNumber] = useState('');
    const [numOfSeats, setNumOfSeats] = useState('');
    const [numOfComputers, setNumOfComputers] = useState('');
    const [isProjector, setIsProjector] = useState(false);
    const [isBoard, setIsBoard] = useState(false);
    const [loading, setLoading] = useState(false);
    const [errorMessage, setErrorMessage] = useState('');
    const [successMessage, setSuccessMessage] = useState('');

    const handleSubmit = async (e) => {
        e.preventDefault();
        setLoading(true);
        setErrorMessage('');
        setSuccessMessage('');
        try {
            await axios.put('http://localhost:5036/api/Room', {
                roomNumber: Number(roomNumber),
                numOfSeats: numOfSeats ? Number(numOfSeats) : undefined,
                numOfComputers: numOfComputers ? Number(numOfComputers) : undefined,
                isProjector,
                isBoard,
            });
            setSuccessMessage('Room updated successfully!');
            setRoomNumber('');
            setNumOfSeats('');
            setNumOfComputers('');
            setIsProjector(false);
            setIsBoard(false);
        } catch (error) {
            setErrorMessage('Error updating room');
        }
        setLoading(false);
    };

    return (
        <div className="container d-flex justify-content-center align-items-center vh-100" style={{ backgroundColor: '#f8f9fa' }}>
            <div className="card p-4 shadow" style={{ width: '400px' }}>
                <h2 className="text-center mb-4">עדכון חדר</h2>
                <form onSubmit={handleSubmit}>
                    <div className="mb-3">
                        <label className="form-label">מספר חדר:</label>
                        <input
                            type="number"
                            className="form-control"
                            value={roomNumber}
                            onChange={(e) => setRoomNumber(e.target.value)}
                            required
                        />
                    </div>
                    <div className="mb-3">
                        <label className="form-label">מספר מושבים:</label>
                        <input
                            type="number"
                            className="form-control"
                            value={numOfSeats}
                            onChange={(e) => setNumOfSeats(e.target.value)}
                        />
                    </div>
                    <div className="mb-3">
                        <label className="form-label">מספר מחשבים:</label>
                        <input
                            type="number"
                            className="form-control"
                            value={numOfComputers}
                            onChange={(e) => setNumOfComputers(e.target.value)}
                        />
                    </div>
                    <div className="form-check mb-2">
                        <input
                            type="checkbox"
                            className="form-check-input"
                            id="projector"
                            checked={isProjector}
                            onChange={(e) => setIsProjector(e.target.checked)}
                        />
                        <label className="form-check-label" htmlFor="projector">
                            מקרן
                        </label>
                    </div>
                    <div className="form-check mb-3">
                        <input
                            type="checkbox"
                            className="form-check-input"
                            id="board"
                            checked={isBoard}
                            onChange={(e) => setIsBoard(e.target.checked)}
                        />
                        <label className="form-check-label" htmlFor="board">
                            לוח
                        </label>
                    </div>
                    <button type="submit" className="btn btn-primary w-100" disabled={loading}>
                        {loading ? 'שולח...' : 'עדכן'}
                    </button>
                </form>
                {errorMessage && <p className="text-danger mt-3">{errorMessage}</p>}
                {successMessage && <p className="text-success mt-3">{successMessage}</p>}
            </div>
        </div>
    );
};
export default UpdateRoom;
