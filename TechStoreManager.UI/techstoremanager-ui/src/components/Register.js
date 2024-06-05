import React, { useState } from 'react';
import AuthService from '../services/authService'; 

const Register = () => {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [error, setError] = useState('');
    const [success, setSuccess] = useState(false);
    const authService = new AuthService();
    const handleRegister = async (e) => {
        e.preventDefault();
        try {
            const response = await authService.register(email, password);
            console.log('Registration successful', response);
            setSuccess(true);
            setError('');
        } catch (err) {
            setError('Registration failed');
            console.error('Registration error:', err);
        }
    };

    return (
        <div>
            <h2>Register</h2>
            <form onSubmit={handleRegister}>
                <div>
                    <label htmlFor="email">Email:</label>
                    <input
                        type="email"
                        id="email"
                        value={email}
                        onChange={e => setEmail(e.target.value)}
                        required
                    />
                </div>
                <div>
                    <label htmlFor="password">Password:</label>
                    <input
                        type="password"
                        id="password"
                        value={password}
                        onChange={e => setPassword(e.target.value)}
                        required
                    />
                </div>
                <button type="submit">Register</button>
            </form>
            {error && <p>{error}</p>}
            {success && <p>Registration successful!</p>}
        </div>
    );
};

export default Register;
