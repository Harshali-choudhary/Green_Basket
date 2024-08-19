import React, { useState } from 'react';
import axios from 'axios';
import './vegetableAddform.css'; // Ensure you create this CSS file for styling

const VegetableAddForm = () => {
    const [imageUrl, setImageUrl] = useState('');
    const [vegetableName, setVegetableName] = useState('');
    const [vegetablePrice, setVegetablePrice] = useState('');
    const [quantity, setQuantity] = useState('');
    const [error, setError] = useState('');
    const [success, setSuccess] = useState('');

    const handleSubmit = async (event) => {
        event.preventDefault();
        setError('');
        setSuccess('');

        const vegetable = {
            image_url: imageUrl,
            vegetable_name: vegetableName,
            vegetable_price: parseFloat(vegetablePrice),
            quantity: parseInt(quantity, 10)
        };

        try {
            const response = await axios.post('https://localhost:7287/api/Vegetables/Insert', vegetable);

            if (response.data.Success) {
                setSuccess('Vegetable added successfully!');
                // Clear form fields
                setImageUrl('');
                setVegetableName('');
                setVegetablePrice('');
                setQuantity('');
            } else {
                setError(response.data.Message || 'Failed to add vegetable.');
            }
        } catch (error) {
            console.error('Add vegetable error:', error);
            setError('An error occurred while adding the vegetable.');
        }
    };

    return (
        <div className="vegetable-add-form">
            <h2>Add Vegetable</h2>
            <form onSubmit={handleSubmit}>
                <div>
                    <label>Image URL:</label>
                    <input
                        type="url"
                        value={imageUrl}
                        onChange={(e) => setImageUrl(e.target.value)}
                        required
                    />
                </div>
                <div>
                    <label>Vegetable Name:</label>
                    <input
                        type="text"
                        value={vegetableName}
                        onChange={(e) => setVegetableName(e.target.value)}
                        required
                    />
                </div>
                <div>
                    <label>Vegetable Price:</label>
                    <input
                        type="number"
                        step="0.01"
                        value={vegetablePrice}
                        onChange={(e) => setVegetablePrice(e.target.value)}
                        required
                    />
                </div>
                <div>
                    <label>Quantity:</label>
                    <input
                        type="number"
                        min="1"
                        value={quantity}
                        onChange={(e) => setQuantity(e.target.value)}
                        required
                    />
                </div>
                <button type="submit">Add Vegetable</button>
            </form>
            {error && <p className="error">{error}</p>}
            {success && <p className="success">{success}</p>}
        </div>
    );
};

export default VegetableAddForm;
