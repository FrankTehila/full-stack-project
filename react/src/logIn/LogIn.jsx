import React, { useState } from 'react';
import axios from 'axios';

const LogIn = () => {
    const [id, setId] = useState('');
    const [isTeamLeader, setIsTeamLeader] = useState(null); // ����� �� ������ �� ������
    const [password, setPassword] = useState('');

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            const response = await axios.post('/api/login', { id: parseInt(id) });

            // ����� ������ �� true/false
            setIsTeamLeader(response.data);
        } catch (error) {
            console.error("����� �������:", error);
        }
    };

    const handlePasswordLogin = async (e) => {
        e.preventDefault();
        console.log("����� ���� �� �����");
        // ����� ������� ��
    };

    return (
        <>
            {isTeamLeader === null ? (
                <form onSubmit={handleSubmit}>
                    <div>
                        <label>
                            ����� ����:
                            <input
                                type="text"
                                value={id}
                                onChange={(e) => setId(e.target.value)}
                                required
                            />
                        </label>
                    </div>
                    <button type="submit">�����</button>
                </form>
            ) : (
                isTeamLeader ? (
                    <form onSubmit={handlePasswordLogin}>
                        <div>
                            <label>
                                �����:
                                <input
                                    type="password"
                                    value={password}
                                    onChange={(e) => setPassword(e.target.value)}
                                    required
                                />
                            </label>
                        </div>
                        <button type="submit">����� ���� ����</button>
                    </form>
                ) : (
                    <div>
                        <h2>������ ����� ���� ������!</h2>
                    </div>
                )
            )}
        </>
    );
};

export default LogIn;