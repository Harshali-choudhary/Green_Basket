import React, { useEffect, useState } from 'react';
import axios from 'axios';
import './Profile.css'; // Make sure you have this CSS file for styling

const Profile = () => {
    const [user, setUser] = useState(null);

    useEffect(() => {
        // Fetch the user data from your API
        axios.get('/api/currentuser') // Adjust the API endpoint as needed
            .then(response => {
                setUser(response.data);
            })
            .catch(error => {
                console.error("There was an error fetching the user data!", error);
            });
    }, []);

    if (!user) {
        return <div>Loading...</div>;
    }

    return (
        <div className="profile-container">
            <h1>Profile</h1>
            <div className="profile-details">
                <p><strong>First Name:</strong> {user.firstName}</p>
                <p><strong>Last Name:</strong> {user.lastName}</p>
                <p><strong>Email:</strong> {user.email}</p>
                <p><strong>Address:</strong> {user.address}</p>
                <p><strong>Phone:</strong> {user.phone}</p>
            </div>
            <button className="edit-button" onClick={() => {/* Handle edit profile */ }}>Edit Profile</button>
        </div>
    );
};

export default Profile;
