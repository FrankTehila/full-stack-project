import React, { useState } from "react";
import axios from "axios";
import "../addMeeting/MeetingForm.css";
import 'bootstrap/dist/css/bootstrap.min.css';

const AddWorker = () => {
    const [id, setId] = useState('');
    const [email, setEmail] = useState('');
    const [firstName, setFirstName] = useState('');
    const [lastName, setLastName] = useState('');
    const [leaderId, setLeaderId] = useState(''); // חדש
    const [loading, setLoading] = useState(false);
    const [errorMessage, setErrorMessage] = useState('');
    const [successMessage, setSuccessMessage] = useState('');

    const handleSubmit = async (e) => {
        e.preventDefault();
        setLoading(true);
        setErrorMessage('');
        setSuccessMessage('');
        try {
            // בניית אובייקט דינאמי, רק עם שדות שמולאו
            const data = {
                id: Number(id),
                email,
                firstName,
                lastName
            };
            // אם הוזן LeaderId, הוסף אותו
            if (leaderId.trim() !== '') {
                data.leaderId = Number(leaderId);
            }

            await axios.post("http://localhost:5036/api/Worker/AddWorker", data);
            setSuccessMessage('העובד נוסף בהצלחה!');
            setId('');
            setEmail('');
            setFirstName('');
            setLastName('');
            setLeaderId('');
        } catch (error) {
            setErrorMessage('שגיאה בהוספת עובד');
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



// const AddWorker = () => {
//     const [form, setForm] = useState({
//         id: "",
//         email: "",
//         firstName: "",
//         lastName: "",
//     });

//     const handleChange = (e) => {
//         const { name, value } = e.target;
//         setForm((prev) => ({
//             ...prev,
//             [name]: value,
//         }));
//     };

//     const handleSubmit = async (e) => {
//         e.preventDefault();
//         // שלח את הנתונים לשרת (עדכן את ה-URL בהתאם)
//         await fetch("http://localhost:5036/api/Worker/AddWorker", {
//             method: "POST",
//             headers: { "Content-Type": "application/json" },
//             body: JSON.stringify({
//                 id: Number(form.id),
//                 email: form.email,
//                 firstName: form.firstName,
//                 lastName: form.lastName
//             }),
//         });
//         setForm({
//             id: "",
//             email: "",
//             firstName: "",
//             lastName: "",
//         });
//     };

//     return (
//         <form onSubmit={handleSubmit}>
//             <div>
//                 <label>ID:</label>
//                 <input
//                     type="number"
//                     name="id"
//                     value={form.id}
//                     onChange={handleChange}
//                     required
//                 />
//             </div>
//             <div>
//                 <label>First Name:</label>
//                 <input
//                     type="text"
//                     name="firstName"
//                     value={form.firstName}
//                     onChange={handleChange}
//                     required
//                 />
//             </div>
//             <div>
//                 <label>Last Name:</label>
//                 <input
//                     type="text"
//                     name="lastName"
//                     value={form.lastName}
//                     onChange={handleChange}
//                     required
//                 />
//             </div>
//             <div>
//                 <label>Email:</label>
//                 <input
//                     type="email"
//                     name="email"
//                     value={form.email}
//                     onChange={handleChange}
//                     required
//                 />
//             </div>
//             <button type="submit">שלח</button>
//         </form>
//     );
// };

// export default AddWorker;