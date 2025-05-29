import React, { useState } from "react";
import axios from "axios";
import "../addMeeting/MeetingForm.css";
import 'bootstrap/dist/css/bootstrap.min.css';
const UpdateWorker = () => {
    const [id, setId] = useState('');
    const [email, setEmail] = useState('');
    const [firstName, setFirstName] = useState('');
    const [lastName, setLastName] = useState('');
    const [loading, setLoading] = useState(false);
    const [errorMessage, setErrorMessage] = useState('');
    const [successMessage, setSuccessMessage] = useState('');

    const handleSubmit = async (e) => {
        e.preventDefault();
        setLoading(true);
        setErrorMessage('');
        setSuccessMessage('');
        try {
            const data = {
                id: Number(id),
            };
            if (email.trim() !== '') data.email = email;
            if (firstName.trim() !== '') data.firstName = firstName;
            if (lastName.trim() !== '') data.lastName = lastName;

            await axios.put("http://localhost:5036/api/Worker/UpdateWorker", data);
            setSuccessMessage('העובד עודכן בהצלחה!');
            setId('');
            setEmail('');
            setFirstName('');
            setLastName('');
        } catch (error) {
            setErrorMessage('שגיאה בעדכון עובד');
        }
        setLoading(false);
    };

    return (
        <div className="container d-flex justify-content-center align-items-center vh-100" style={{ backgroundColor: '#f8f9fa' }}>
            <div className="card p-4 shadow" style={{ width: '400px' }}>
                <h2 className="text-center mb-4">עדכון עובד</h2>
                <form onSubmit={handleSubmit}>
                    <div className="mb-3">
                        <label className="form-label">תעודת זהות:</label>
                        <input
                            type="number"
                            className="form-control"
                            value={id}
                            onChange={(e) => setId(e.target.value)}
                            required
                        />
                    </div>
                    <div className="mb-3">
                        <label className="form-label">שם פרטי:</label>
                        <input
                            type="text"
                            className="form-control"
                            value={firstName}
                            onChange={(e) => setFirstName(e.target.value)}
                        />
                    </div>
                    <div className="mb-3">
                        <label className="form-label">שם משפחה:</label>
                        <input
                            type="text"
                            className="form-control"
                            value={lastName}
                            onChange={(e) => setLastName(e.target.value)}
                        />
                    </div>
                    <div className="mb-3">
                        <label className="form-label">אימייל:</label>
                        <input
                            type="email"
                            className="form-control"
                            value={email}
                            onChange={(e) => setEmail(e.target.value)}
                        />
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

export default UpdateWorker;

