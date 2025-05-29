import { useState } from 'react';
import axios from 'axios';
import { useDispatch, useSelector } from 'react-redux';
import { setUserKind } from '../store/proxy';
import { useNavigate } from 'react-router-dom';
import 'bootstrap/dist/css/bootstrap.min.css';
import './LogIn.css';
import Navigation from '../navigation/Navigation';

const LogIn = () => {
    const dispatch = useDispatch();
    const userKind = useSelector((state) => state.proxy.userKind);
    const navigate = useNavigate();

    const [id, setId] = useState('');
    const [password, setPassword] = useState('');
    const [errorMessage, setErrorMessage] = useState('');
    const [loading, setLoading] = useState(false);
    const [isLoggedIn, setIsLoggedIn] = useState(false);
    const [simpleWorkerEnter, setSimpleWorkerEnter] = useState(false);

    const validateId = (id) => {
        const idRegex = /^[0-9]{1,9}$/;
        return idRegex.test(id);
    };

    const handleLogin = async (e) => {
        e.preventDefault();
        setLoading(true);
        setErrorMessage('');

        if (!validateId(id)) {
            setLoading(false);
            setErrorMessage('Invalid ID');
            return;
        }

        try {
            const response = await axios.post('https://localhost:7065/api/Login', { Id: parseInt(id) });
            dispatch(setUserKind(response.data));
            setLoading(false);
            if (response.data === 0) setSimpleWorkerEnter(true);
            setIsLoggedIn(response.data === 0);
        } catch (error) {
            setLoading(false);
            if (!error.response) {
                setErrorMessage('Network error, please check your connection.');
            } else {
                // טיפול בשגיאה שנזרקה מהשרת
                if (error.response.status === 400) {
                    setErrorMessage(error.response.data.message || 'Invalid request.');
                } else {
                    setErrorMessage(error.response.data.message);
                }
            }
        }
    };

    const handleRegularEnter = () => {
        setSimpleWorkerEnter(true);
        setIsLoggedIn(true); // הכנס את המשתמש כעובד פשוט
    };

    const handleLoginTeamLeader = async (e) => {
        e.preventDefault();
        setLoading(true);
        setErrorMessage('');
        if (password === userKind) {
            navigate('/');
        } else {
            setLoading(false);
            setErrorMessage("The password is not correct!!");
        }
    };

    if (isLoggedIn) {
        return <Navigation />;
    }

    return (
        <div className="container d-flex justify-content-center align-items-center vh-100" style={{ backgroundColor: '#343a40' }}>
            <div className="card p-4 shadow" style={{ width: '400px' }}>
                <h2 className="text-center mb-4">Log-In</h2>
                <form onSubmit={handleLogin}>
                    <div className="mb-3">
                        <label className="form-label">Insert ID to connect:</label>
                        <input
                            type="text"
                            className="form-control"
                            value={id}
                            onChange={(e) => setId(e.target.value)}
                            required
                        />
                    </div>
                    <button type="submit" className="btn btn-primary w-100" disabled={loading || userKind !== 0}>
                        {loading ? 'Loading...' : 'Connect'}
                    </button>
                </form>

                {userKind != 0 && (
                    <div>
                        <form onSubmit={handleLoginTeamLeader} className="mt-4">
                            <div className="mb-3">
                                <label className="form-label">Password:</label>
                                <input
                                    type="password"
                                    className="form-control"
                                    value={password}
                                    onChange={(e) => setPassword(e.target.value)}
                                    required
                                />
                            </div>
                            <button type="submit" className="btn btn-primary w-100" disabled={loading}>
                                {loading ? 'Loading...' : 'Log in as a team leader'}
                            </button>
                        </form>

                        <button onClick={handleRegularEnter} className="btn btn-secondary w-100 mt-2">
                            Login as an employee
                        </button>
                    </div>
                )}
                {errorMessage && <p className="text-danger mt-2">{errorMessage}</p>}
            </div>
        </div>
    );
}

export default LogIn;
