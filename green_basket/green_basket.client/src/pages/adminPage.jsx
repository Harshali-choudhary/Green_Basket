import React from 'react';
import { useNavigate } from 'react-router-dom';

const AdminDashboard = () => {
    const navigate = useNavigate();

    const handleAddVegetableClick = () => {
        navigate('/add-vegetable');
    };

    const handleDeleteVegetableClick = () => {
        navigate('/delete-vegetable');
    };

    const handleUpdateVegetableClick = () => {
        navigate('/update-vegetable');
    };

    return (
        <div className="admin-dashboard">
            <h1>Admin Dashboard</h1>
            <button onClick={handleAddVegetableClick}>Add Vegetable</button>
            <button onClick={handleDeleteVegetableClick}>Delete Vegetable</button>
            <button onClick={handleUpdateVegetableClick}>Update Vegetable</button>
            
        </div>
    );
};

export default AdminDashboard;
