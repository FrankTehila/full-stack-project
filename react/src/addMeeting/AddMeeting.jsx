import React, { useState } from "react";
import MeetingForm from "./MeetingForm";
import 'bootstrap/dist/css/bootstrap.min.css';

const AddMeeting = () => {
    const [showForm, setShowForm] = useState(false);

    const handleButtonClick = () => {
        setShowForm(true);
    };

    return (
        <div className="container text-center mt-4">
            <button
                onClick={handleButtonClick}
                className="btn btn-secondary mb-3"
            >
                add team meeting            
            </button>
            {showForm && <MeetingForm />}
        </div>
    );
};

export default AddMeeting;
