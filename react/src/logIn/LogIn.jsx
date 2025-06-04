import { useState } from 'react';
import axios from 'axios';
import { useDispatch, useSelector } from 'react-redux';
import { setUserKind } from '../store/proxy';
import Navigation from '../navigation/Navigation';
import 'bootstrap/dist/css/bootstrap.min.css';
import './LogIn.css';

const LogIn = () => {
    const dispatch = useDispatch();
    const userKind = useSelector((state) => state.proxy.userKind);

    const [id, setId] = useState('');
    const [password, setPassword] = useState('');
    const [errorMessage, setErrorMessage] = useState('');
    const [loading, setLoading] = useState(false);
    const [isLoggedIn, setIsLoggedIn] = useState(false);
    const [infoMessage, setInfoMessage] = useState('');

    const validateId = (id) => /^[0-9]{1,9}$/.test(id);

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
            localStorage.setItem('token', response.data.token);

            dispatch(setUserKind(response.data.userKind));
            setLoading(false);
            if (response.data.userKind === 0) {
                setIsLoggedIn(true);
                setInfoMessage('');
            } else {
                setInfoMessage("A login code was sent to your email.");
                setErrorMessage('');
            }
        } catch (error) {
            setLoading(false);
            setInfoMessage('');
            if (!error.response) {
                setErrorMessage('Network error, please check your connection.');
            } else if (error.response.status === 400) {
                setErrorMessage(error.response.data.message || 'Invalid request.');
            } else {
                setErrorMessage(error.response.data.message);
            }
        }
    };

    const handleLoginTeamLeader = async (e) => {
        e.preventDefault();
        setLoading(true);
        setErrorMessage('');
        if (password == userKind) {
            setIsLoggedIn(true);
        } else {
            setLoading(false);
            setErrorMessage("The code you entered is incorrect!");
        }
    };

    if (isLoggedIn) {
        return <Navigation />;
    }

    return (
        <div className="container d-flex justify-content-center align-items-center vh-100" style={{ backgroundColor: '#343a40' }}>
            <div className="card p-4 shadow" style={{ width: '400px' }}>
                <h2 className="text-center mb-4">Log In</h2>
                <form onSubmit={handleLogin}>
                    <div className="mb-3">
                        <label className="form-label">Enter your ID number:</label>
                        <input
                            type="text"
                            className="form-control"
                            value={id}
                            onChange={(e) => setId(e.target.value)}
                            required
                        />
                    </div>
                    <button type="submit" className="btn btn-primary w-100" disabled={loading || userKind !== 0}>
                        {loading ? 'Loading...' : 'Log In'}
                    </button>
                </form>

                {userKind != 0 && (
                    <div>
                        {infoMessage && (
                            <p className="text-center" style={{ color: '#adb5bd', fontWeight: 'bold' }}>
                                {infoMessage}
                            </p>
                        )}
                        <form onSubmit={handleLoginTeamLeader} className="mt-4">
                            <div className="mb-3">
                                <label className="form-label">Login code:</label>
                                <input
                                    type="password"
                                    className="form-control"
                                    value={password}
                                    onChange={(e) => setPassword(e.target.value)}
                                    required
                                />
                            </div>
                            <button type="submit" className="btn btn-primary w-100" disabled={loading}>
                                {loading ? 'Loading...' : 'Log in as Team Leader'}
                            </button>
                        </form>
                    </div>
                )}
                {errorMessage && <p className="text-danger mt-2">{errorMessage}</p>}
            </div>
        </div>
    );
}

export default LogIn;