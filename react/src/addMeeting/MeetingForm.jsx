const MeetingForm = () => {
    
        // const handleChange = (e) => {
        //     const { name, value } = e.target;
        //     setMeetingDetails({
        //         ...meetingDetails,
        //         [name]: value
        //     });
        // };
    
        const handleSubmit = (e) => {
            //e.preventDefault();
            //קריאת API להוספת פגישה
            //console.log(meetingDetails);
        };

    return(
         <form onSubmit={handleSubmit}>
            <div>
                <label htmlFor="date">תאריך:</label>
                <input 
                    type="date" 
                    id="date" 
                    name="date"
                    //onChange={handleChange} 
                    required 
                />
            </div>
            <div>
                <label htmlFor="time">שעה:</label>
                <input 
                    type="time" 
                    id="time" 
                    name="time" 
                    //onChange={handleChange} 
                    required 
                />
            </div>
            <div>
                <label htmlFor="duration">משך זמן (שעות):</label>
                <input 
                    type="number" 
                    id="duration" 
                    name="duration"
                    //onChange={handleChange} 
                    required 
                />
            </div>
            <div>
                <label htmlFor="roomNumber">מקרן?</label>
                <input 
                    type="checkbox" 
                    id="roomNumber" 
                    name="roomNumber" 
                    value={meetingDetails.roomNumber} 
                    //onChange={handleChange} 
                    required 
                />
            </div>
            <div>
                <label htmlFor="roomNumber">לוח?</label>
                <input 
                    type="checkbox" 
                    id="roomNumber" 
                    name="roomNumber" 
                    value={meetingDetails.roomNumber} 
                    //onChange={handleChange} 
                    required 
                />
            </div>
            <button type="submit">הזמן פגישה</button>
        </form>
    )
}
export default MeetingForm;