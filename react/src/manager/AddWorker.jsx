import React, { useState } from "react";
import axios from "axios";
import "../addMeeting/MeetingForm.css";
import 'bootstrap/dist/css/bootstrap.min.css';

const AddWorker = () => {
    const [id, setId] = useState('');
    const [email, setEmail] = useState('');
    const [firstName, setFirstName] = useState('');
    const [lastName, setLastName] = useState('');
    const [leaderId, setLeaderId] = useState('');
    const [loading, setLoading] = useState(false);
    const [errorMessage, setErrorMessage] = useState('');
    const [successMessage, setSuccessMessage] = useState('');

    const handleSubmit = async (e) => {
        e.preventDefault();
        setLoading(true);
        setErrorMessage('');
        setSuccessMessage('');

        const data = {
            id: Number(id),
            email: email.trim() !== '' ? email : 'default@email.com',
            firstName,
            lastName
        };

        if (leaderId.trim() === '') {
            data.numOfWorkers = 0;
        } else {
            data.leaderId = Number(leaderId);
        }

        console.log("שליחת נתונים לשרת:", JSON.stringify(data, null, 2));

        try {
            const response = await axios.post("http://localhost:5036/api/Worker", data, {
                headers: { 'Content-Type': 'application/json' }
            });

            console.log("תגובת שרת:", JSON.stringify(response.data, null, 2));
            setSuccessMessage('העובד נוסף בהצלחה');
            setId('');
            setEmail('');
            setFirstName('');
            setLastName('');
            setLeaderId('');
        } catch (error) {
            console.error("שגיאת שרת:", JSON.stringify(error.response?.data || error.message, null, 2));
            setErrorMessage(`שגיאה בהוספת עובד: ${error.response?.data || error.message}`);
        }

        setLoading(false);
    };

    return (
        <div className="container d-flex justify-content-center align-items-center vh-100" style={{ backgroundColor: '#f8f9fa' }}>
            <div className="card p-4 shadow" style={{ width: '400px' }}>
                <h2 className="text-center mb-4">הוספת עובד</h2>
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
                            required
                        />
                    </div>
                    <div className="mb-3">
                        <label className="form-label">שם משפחה:</label>
                        <input
                            type="text"
                            className="form-control"
                            value={lastName}
                            onChange={(e) => setLastName(e.target.value)}
                            required
                        />
                    </div>
                    <div className="mb-3">
                        <label className="form-label">אימייל:</label>
                        <input
                            type="email"
                            className="form-control"
                            value={email}
                            onChange={(e) => setEmail(e.target.value)}
                            required
                        />
                    </div>
                    <div className="mb-3">
                        <label className="form-label">מספר מנהל ישיר (לא חובה):</label>
                        <input
                            type="number"
                            className="form-control"
                            value={leaderId}
                            onChange={(e) => setLeaderId(e.target.value)}
                            min="1"
                        />
                    </div>
                    <button type="submit" className="btn btn-primary w-100" disabled={loading}>
                        {loading ? 'שולח...' : 'הוסף'}
                    </button>
                </form>
                {errorMessage && <p className="text-danger mt-3">{errorMessage}</p>}
                {successMessage && <p className="text-success mt-3">{successMessage}</p>}
            </div>
        </div>
    );
};

export default AddWorker;