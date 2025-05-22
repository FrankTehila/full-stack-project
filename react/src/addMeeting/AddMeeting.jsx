import React, { useState } from "react";
import MeetingForm from "./MeetingForm";
import 'bootstrap/dist/css/bootstrap.min.css';

const AddMeeting = () => {
    const [isFormVisible, setFormVisible] = useState(false); // Manage the visibility state of the form

    const handleButtonClick = () => {
        setFormVisible(!isFormVisible); // Toggle the visibility state of the form
    };

    return (
        <div className="container text-center mt-4">
            <button 
                onClick={handleButtonClick} 
                className="btn btn-secondary mb-3"
            >
                {isFormVisible ? "Hide Form" : "Add Team Meeting"}
            </button>
            {isFormVisible && <MeetingForm />} {/* Show the form if isFormVisible is true */}
        </div>
    );
};

export default AddMeeting;
