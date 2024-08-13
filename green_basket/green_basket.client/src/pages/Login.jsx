import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import axios from 'axios';
import './login.css'; // Ensure this file exists and is correctly referenced

const Login = () => {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [error, setError] = useState('');
    const navigate = useNavigate();

    const handleLogin = async (e) => {
        e.preventDefault();
        setError(''); // Clear any existing errors

        // Basic validation
        if (!email || !password) {
            setError('Email and password are required.');
            return;
        }

        const emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        if (!emailPattern.test(email)) {
            setError('Please enter a valid email address.');
            return;
        }

        if (password.length < 6) {
            setError('Password must be at least 6 characters long.');
            return;
        }

        try {
            const response = await axios.post('https://localhost:7287/api/Users/Login',
                { email, password },
                { headers: { 'Content-Type': 'application/json', 'Accept': 'application/json' } }
            );

            console.log('Response Status:', response.status);
            console.log('Response Data:', response.data);

            if (response.status === 200) {
                navigate('/'); // Redirect to home or another page after successful login
            } else {
                setError(`Unexpected response status: ${response.status}`);
            }
        } catch (err) {
            console.error('Login error:', err);
            if (err.response) {
                // Handle API errors
                setError(`Error ${err.response.status}: ${err.response.data?.message || 'An error occurred.'}`);
            } else if (err.request) {
                // Handle network errors
                setError('Network error: Please check your connection.');
            } else {
                // Handle other errors
                setError('Error: ' + err.message);
            }
        }
    };

    return (
        <div className="login-container">
            <h2>Login</h2>
            <form onSubmit={handleLogin}>
                <div className="form-group">
                    <label htmlFor="email">Email:</label>
                    <input
                        type="email"
                        id="email"
                        value={email}
                        onChange={(e) => setEmail(e.target.value)}
                        required
                    />
                </div>
                <div className="form-group">
                    <label htmlFor="password">Password:</label>
                    <input
                        type="password"
                        id="password"
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                        required
                    />
                </div>
                {error && <div className="error-message">{error}</div>}
                <button type="submit" className="login-button">Login</button>
            </form>
        </div>
    );
};

export default Login;
