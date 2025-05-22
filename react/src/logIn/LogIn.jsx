import { useState } from 'react';
import axios from 'axios';
import { useDispatch, useSelector } from 'react-redux';
import { setUserKind } from '../store/proxy';
import { useNavigate, BrowserRouter as Router } from 'react-router-dom';
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
            const response = await axios.post('/api/Login', { id: parseInt(id) });
            dispatch(setUserKind(response.data.userKind));
            setLoading(false);
            setIsLoggedIn(true);
        } catch (error) {
            setLoading(false);
            console.error('Connect error:', error);
            setErrorMessage(error.response?.data?.message || 'Connect error, try again.');
        }
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
                    <button type="submit" className="btn btn-primary w-100" disabled={loading}>
                        {loading ? 'Loading...' : 'Connect'}
                    </button>
                </form>
                {errorMessage && <p className="text-danger">{errorMessage}</p>}

                {userKind !== 0 && (
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
                            {loading ? 'Loading...' : 'Connect'}
                        </button>
                    </form>
                )}
            </div>
            <button onClick={(e) => setIsLoggedIn(true)}></button>
        </div>
    );
}

export default LogIn;
