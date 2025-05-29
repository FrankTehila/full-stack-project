
import React, { useState } from "react";
import axios from "axios";
import "../addMeeting/MeetingForm.css"; 
import 'bootstrap/dist/css/bootstrap.min.css';
const AddRoom = () => {
    const [Id, setId] = useState('');
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
            await axios.post('http://localhost:5036/api/Room', {
                Id,
                numOfSeats: Number(numOfSeats),
                numOfComputers: Number(numOfComputers),
                isProjector,
                isBoard,
            });
            setSuccessMessage('Room added successfully!');
            setId('');
            setNumOfSeats('');
            setNumOfComputers('');
            setIsProjector(false);
            setIsBoard(false);
        } catch (error) {
            setErrorMessage('Error adding room');
        }
        setLoading(false);
    };

    return (
        <div className="container d-flex justify-content-center align-items-center vh-100" style={{ backgroundColor: '#f8f9fa' }}>
            <div className="card p-4 shadow" style={{ width: '400px' }}>
                <h2 className="text-center mb-4">הוספת חדר</h2>
                <form onSubmit={handleSubmit}>
                    <div className="mb-3">
                        <label className="form-label">מספר חדר:</label>
                        <input
                            type="text"
                            className="form-control"
                            value={Id}
                            onChange={(e) => setId(e.target.value)}
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
                            required
                        />
                    </div>
                    <div className="mb-3">
                        <label className="form-label">מספר מחשבים:</label>
                        <input
                            type="number"
                            className="form-control"
                            value={numOfComputers}
                            onChange={(e) => setNumOfComputers(e.target.value)}
                            required
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
                        {loading ? 'שולח...' : 'הוסף'}
                    </button>
                </form>
                {errorMessage && <p className="text-danger mt-3">{errorMessage}</p>}
                {successMessage && <p className="text-success mt-3">{successMessage}</p>}
            </div>
        </div>
    );
};

export default AddRoom;
// import React, { useState } from "react";
// import axios from "axios";
// import "../addMeeting/MeetingForm.css"; 
// import { useState } from 'react';
// import axios from 'axios';
// import 'bootstrap/dist/css/bootstrap.min.css';

// const AddRoom = () => {
//     const [form, setForm] = useState({
//         Id: "",
//         numOfSeats: "",
//         numOfComputers: "",
//         isProjector: false,
//         isBoard: false,
//     });

//     const handleChange = (e) => {
//         const { name, value, type, checked } = e.target;
//         setForm((prev) => ({
//             ...prev,
//             [name]: type === "checkbox" ? checked : value,
//         }));
//     };

//     const handleSubmit = async (e) => {
//         e.preventDefault();
//         try {
//             // Adjust the URL to your API endpoint
//             await axios.post("http://localhost:5036/api/Worker/AddWorker", {
//                 Id: form.Id, // הוספת מספר החדר
//                 numOfSeats: Number(form.numOfSeats),
//                 numOfComputers: Number(form.numOfComputers),
//                 isProjector: form.isProjector,
//                 isBoard: form.isBoard,
//             });
//             alert("Room added successfully!");
//             setForm({
//                 Id: "", // איפוס מספר החדר
//                 numOfSeats: "",
//                 numOfComputers: "",
//                 isProjector: false,
//                 isBoard: false,
//             });
//         } catch (error) {
//             alert("Error adding room");
//         }
//     };

//     return (
//         <form onSubmit={handleSubmit} style={{ maxWidth: 400, margin: "auto" }}>
//             <h2>הוספת חדר</h2>
//             <div>
//                 <label>מספר חדר:</label>
//                 <input
//                     type="text"
//                     name="Id"
//                     value={form.Id}
//                     onChange={handleChange}
//                     required
//                 />
//             </div>
//             <div>
//                 <label>מספר מושבים:</label>
//                 <input
//                     type="number"
//                     name="numOfSeats"
//                     value={form.numOfSeats}
//                     onChange={handleChange}
//                     required
//                 />
//             </div>
//             <div>
//                 <label>מספר מחשבים:</label>
//                 <input
//                     type="number"
//                     name="numOfComputers"
//                     value={form.numOfComputers}
//                     onChange={handleChange}
//                     required
//                 />
//             </div>
//             <div>
//                 <label>
//                     מקרן:
//                     <input
//                         type="checkbox"
//                         name="isProjector"
//                         checked={form.isProjector}
//                         onChange={handleChange}
//                     />
//                 </label>
//             </div>
//             <div>
//                 <label>
//                     לוח:
//                     <input
//                         type="checkbox"
//                         name="isBoard"
//                         checked={form.isBoard}
//                         onChange={handleChange}
//                     />
//                 </label>
//             </div>
//             <button type="submit">הוסף</button>
//         </form>
//     );
// };

// export default AddRoom;
