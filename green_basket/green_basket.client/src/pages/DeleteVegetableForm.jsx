import React, { useState } from 'react';
import axios from 'axios';
import './deleteVegetableform.css'; 

const DeleteVegetableForm = () => {
    const [vegetableId, setVegetableId] = useState('');
    const [error, setError] = useState('');
    const [success, setSuccess] = useState('');

    const handleSubmit = async (event) => {
        event.preventDefault();
        setError('');
        setSuccess('');

        try {
            const response = await axios.delete(`https://localhost:7001/api/Vegetables/Delete/${vegetableId}`);

            if (response.data.Success) {
                setSuccess('Vegetable deleted successfully!');
                setVegetableId(''); // Clear the input field
            } else {
                setError(response.data.Message || 'Failed to delete vegetable.');
            }
        } catch (error) {
            console.error('Delete vegetable error:', error);
            setError('An error occurred while deleting the vegetable.');
        }
    };

    return (
        <div className="vegetable-delete-form">
            <h2>Delete Vegetable</h2>
            <form onSubmit={handleSubmit}>
                <div>
                    <label>Vegetable ID:</label>
                    <input
                        type="number"
                        value={vegetableId}
                        onChange={(e) => setVegetableId(e.target.value)}
                        required
                    />
                </div>
                <button type="submit">Delete Vegetable</button>
            </form>
            {error && <p className="error">{error}</p>}
            {success && <p className="success">{success}</p>}
        </div>
    );
};

export default DeleteVegetableForm;
