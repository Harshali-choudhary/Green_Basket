import React, { useState, useEffect } from 'react';
import axios from 'axios';
import './updateVegetableForm.css';

const UpdateVegetableForm = ({ vegetableId, onUpdateSuccess }) => {
    const [vegetable, setVegetable] = useState({
        image_url: '',
        vegetable_name: '',
        vegetable_price: '',
        quantity: ''
    });
    const [error, setError] = useState('');
    const [success, setSuccess] = useState('');

    useEffect(() => {
        const fetchVegetable = async () => {
            try {
                const response = await axios.get(`https://localhost:7287/api/Vegetables/${vegetableId}`);
                setVegetable(response.data);
            } catch (error) {
                console.error('Error fetching vegetable:', error);
                setError('Failed to fetch vegetable details.');
            }
        };

        fetchVegetable();
    }, [vegetableId]);

    const handleChange = (e) => {
        const { name, value } = e.target;
        setVegetable(prevState => ({
            ...prevState,
            [name]: value
        }));
    };

    const handleSubmit = async (event) => {
        event.preventDefault();
        setError('');
        setSuccess('');

        try {
            await axios.put(`https://localhost:7287/api/Vegetables/${vegetableId}`, vegetable);
            setSuccess('Vegetable updated successfully!');
            onUpdateSuccess(); // Call the success callback if provided
        } catch (error) {
            console.error('Update error:', error);
            setError('An error occurred while updating the vegetable.');
        }
    };

    return (
        <div className="vegetable-update-form">
            <h2>Update Vegetable</h2>
            <form onSubmit={handleSubmit}>
                <div>
                    <label htmlFor="image_url">Image URL:</label>
                    <input
                        type="url"
                        id="image_url"
                        name="image_url"
                        value={vegetable.image_url}
                        onChange={handleChange}
                        required
                    />
                </div>
                <div>
                    <label htmlFor="vegetable_name">Vegetable Name:</label>
                    <input
                        type="text"
                        id="vegetable_name"
                        name="vegetable_name"
                        value={vegetable.vegetable_name}
                        onChange={handleChange}
                        required
                    />
                </div>
                <div>
                    <label htmlFor="vegetable_price">Vegetable Price:</label>
                    <input
                        type="number"
                        id="vegetable_price"
                        name="vegetable_price"
                        value={vegetable.vegetable_price}
                        onChange={handleChange}
                        step="0.01"
                        min="0.01"
                        required
                    />
                </div>
                <div>
                    <label htmlFor="quantity">Quantity:</label>
                    <input
                        type="number"
                        id="quantity"
                        name="quantity"
                        value={vegetable.quantity}
                        onChange={handleChange}
                        min="1"
                        required
                    />
                </div>
                <button type="submit">Update Vegetable</button>
            </form>
            {error && <p className="error">{error}</p>}
            {success && <p className="success">{success}</p>}
        </div>
    );
};

export default UpdateVegetableForm;
