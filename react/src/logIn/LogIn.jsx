import React, { useState } from 'react';
import axios from 'axios';

const LogIn = () => {
    const [id, setId] = useState('');
    const [isTeamLeader, setIsTeamLeader] = useState(null); // ישמור את התוצאה של הבדיקה
    const [password, setPassword] = useState('');

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const response = await axios.post('/api/login', { id: parseInt(id) });

            // טיפול בתשובה של true/false
            setIsTeamLeader(response.data);
        } catch (error) {
            console.error("שגיאת התחברות:", error);
        }
    };

    const handlePasswordLogin = async (e) => {
        e.preventDefault();
        console.log("כניסת צוות עם סיסמה");
        // הוספת הלוגיקה פה
    };

    return (
        <>
            {isTeamLeader === null ? (
                <form onSubmit={handleSubmit}>
                    <div>
                        <label>
                            תעודת זהות:
                            <input
                                type="text"
                                value={id}
                                onChange={(e) => setId(e.target.value)}
                                required
                            />
                        </label>
                    </div>
                    <button type="submit">התחבר</button>
                </form>
            ) : (
                isTeamLeader ? (
                    <form onSubmit={handlePasswordLogin}>
                        <div>
                            <label>
                                סיסמה:
                                <input
                                    type="password"
                                    value={password}
                                    onChange={(e) => setPassword(e.target.value)}
                                    required
                                />
                            </label>
                        </div>
                        <button type="submit">התחבר כראש צוות</button>
                    </form>
                ) : (
                    <div>
                        <h2>כניסתך כעובד רגיל התקבלה!</h2>
                    </div>
                )
            )}
        </>
    );
};

export default LogIn;