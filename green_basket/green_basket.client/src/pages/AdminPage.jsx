// src/pages/AdminPage.js
import React from 'react';
import VegetableInsertForm from '../components/VegetableInsertForm';

const AdminPage = ({ isAdmin }) => {
    const handleFormSubmit = (data) => {
        console.log(data);
        // Make a POST request to your API to insert the vegetable data
    };

    if (!isAdmin) {
        return <p>You do not have access to this page.</p>;
    }

    return (
        <div>
            <h1>Insert New Vegetable</h1>
            <VegetableInsertForm onSubmit={handleFormSubmit} />
        </div>
    );
};

export default AdminPage;
