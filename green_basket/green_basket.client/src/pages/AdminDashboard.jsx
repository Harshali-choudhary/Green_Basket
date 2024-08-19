// src/pages/AdminDashboard.js
import React from 'react';
import VegetableInsertForm from '../components/VegetableInsertForm';

const AdminDashboard = () => {
    const handleVegetableSubmit = async (vegetableData) => {
        try {
            const response = await fetch('/api/vegetables', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(vegetableData),
            });

            if (response.ok) {
                alert("Vegetable added successfully!");
                // Optionally, clear form or refresh data
            } else {
                alert("Failed to add vegetable.");
            }
        } catch (error) {
            console.error("Error:", error);
            alert("An error occurred while adding the vegetable.");
        }
    };

    return (
        <div>
            <h2>Admin - Add New Vegetable</h2>
            <VegetableInsertForm onSubmit={handleVegetableSubmit} />
        </div>
    );
};

export default AdminDashboard;
