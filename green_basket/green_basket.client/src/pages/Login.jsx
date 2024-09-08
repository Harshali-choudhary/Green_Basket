import React, { useState } from 'react';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';
import './login.css'; // Make sure to create this CSS file for styling

const Login = () => {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [error, setError] = useState('');
    const [success, setSuccess] = useState('');
    const navigate = useNavigate(); // Create navigate function

    const handleSubmit = async (event) => {
        event.preventDefault();
        setError('');
        setSuccess('');

        try {
            const response = await axios.post('https://localhost:7001/api/Users/Login', {
                email,
                password
            });

            // Debugging: Log the response data
            console.log('API Response:', response.data);

            if (response.data.Success) {
                setSuccess('Login successful!');

                // Redirect based on user role
                if (response.data.Role === 'Admin') {
                    navigate('/adminPage'); // Navigate to the admin page
                } else {
                    navigate('/Shop'); // Navigate to the shop page
                }
            } else {
                setError('Invalid email or password.');
            }
        } catch (error) {
            console.error('Login error:', error);
            setError('An error occurred while logging in.');
        }
    };

    return (
        <div className="login-form">
            <h2>Login</h2>
            <form onSubmit={handleSubmit}>
                <div>
                    <label>Email:</label>
                    <input
                        type="email"
                        value={email}
                        onChange={(e) => setEmail(e.target.value)}
                        required
                    />
                </div>
                <div>
                    <label>Password:</label>
                    <input
                        type="password"
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                        required
                    />
                </div>
                <button type="submit">Login</button>
            </form>
            {error && <p className="error">{error}</p>}
            {success && <p className="success">{success}</p>}
        </div>
    );
};

export default Login;
