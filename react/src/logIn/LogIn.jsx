import React, { useState } from 'react';
import axios from 'axios';
import { useDispatch } from 'react-redux';
import { useSelector } from 'react-redux';

const LogIn = () => {
    
    const dispatch = useDispatch();
    const userKind = useSelector((state) => state.proxy.userKind);

    const [id, setId] = useState('');
    const [password, setPassword] = useState('');
    const [errorMessage, setErrorMessage] = useState('');
    const [loading, setLoading] = useState(false);

    const validateId = (id) => {
        const idRegex = /^[0-9]{1,9}$/; // numbers: 0-9, 9 digits
        return idRegex.test(id);
    };

    const handleLogin = async (e) => {
        e.preventDefault();
        setLoading(true);
        setErrorMessage('');

        if (!validateId(id)) {
            setLoading(false);
            setErrorMessage('invalid ID');
            return;
        }

        try {
            const response = await axios.post('/api/LogIn', parseInt(id));
            dispatch(setUserKind(response.data.userKind)); 
            setLoading(false);
            navigate('/');
        } catch (error) {
            setLoading(false);
            console.error('connect error:', error);
            setErrorMessage(error.response?.data?.message || 'connect error, try again.');
        }
    };

    const handleLoginTeamLeader = async (e) => {
        e.preventDefault();
        setLoading(true);
        setErrorMessage('');
        if (password == teamLeader) {
            navigate('/');
        }
        else {
            setLoading(false);
            setErrorMessage("The password is not correct!!");
        }
    }

    return (
        <>
            <div>
                <h2>connecting</h2>
                <form onSubmit={handleLogin}>
                    <div>
                        <label>
                            insert ID to connect:
                            <input
                                type="text"
                                value={id}
                                onChange={(e) => setId(e.target.value)}
                                required
                            />
                        </label>
                    </div>
                </form>
                {errorMessage && <p style={{ color: 'red' }}>{errorMessage}</p>}
            </div>

            {userKind != null && (
                <div>
                    <form onSubmit={handleLoginTeamLeader}>
                        <div>
                            <label>
                                password:
                                <input
                                    type="password"
                                    value={password}
                                    onChange={(e) => setPassword(e.target.value)}
                                    required
                                />
                            </label>
                        </div>
                        <button type="submit" disabled={loading}>
                            {loading ? 'loading...' : 'connected'}
                        </button>
                    </form>
                    {errorMessage && <p style={{ color: 'red' }}>{errorMessage}</p>}
                </div>
            )}
        </>
    )
}

export default LogIn;