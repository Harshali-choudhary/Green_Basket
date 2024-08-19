// src/components/VegetableInsertForm.js
import React, { useState } from 'react';

const VegetableInsertForm = ({ onSubmit }) => {
    const [formData, setFormData] = useState({
        vegetable_id: '',
        image_url: '',
        vegetable_name: '',
        vegetable_price: '',
        quantity: ''
    });

    const [errors, setErrors] = useState({});

    const handleChange = (e) => {
        const { name, value } = e.target;
        setFormData({
            ...formData,
            [name]: value
        });
    };

    const validate = () => {
        const errors = {};
        if (!formData.vegetable_name) errors.vegetable_name = 'Vegetable name is required.';
        if (formData.vegetable_name.length > 100) errors.vegetable_name = 'Vegetable name cannot be longer than 100 characters.';
        if (formData.vegetable_price <= 0) errors.vegetable_price = 'Vegetable price must be greater than 0.';
        if (formData.quantity < 1) errors.quantity = 'Quantity must be at least 1.';
        return errors;
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        const validationErrors = validate();
        if (Object.keys(validationErrors).length === 0) {
            onSubmit(formData);
        } else {
            setErrors(validationErrors);
        }
    };

    // Replace this with your actual admin check
    const isAdmin = true;

    if (!isAdmin) {
        return <p>You do not have permission to access this page.</p>;
    }

    return (
        <form onSubmit={handleSubmit}>
            <div>
                <label>Vegetable ID:</label>
                <input
                    type="number"
                    name="vegetable_id"
                    value={formData.vegetable_id}
                    onChange={handleChange}
                    required
                />
            </div>
            <div>
                <label>Image URL:</label>
                <input
                    type="url"
                    name="image_url"
                    value={formData.image_url}
                    onChange={handleChange}
                    required
                />
                {errors.image_url && <span>{errors.image_url}</span>}
            </div>
            <div>
                <label>Vegetable Name:</label>
                <input
                    type="text"
                    name="vegetable_name"
                    value={formData.vegetable_name}
                    onChange={handleChange}
                    maxLength="100"
                    required
                />
                {errors.vegetable_name && <span>{errors.vegetable_name}</span>}
            </div>
            <div>
                <label>Vegetable Price:</label>
                <input
                    type="number"
                    name="vegetable_price"
                    value={formData.vegetable_price}
                    onChange={handleChange}
                    min="0.01"
                    step="0.01"
                    required
                />
                {errors.vegetable_price && <span>{errors.vegetable_price}</span>}
            </div>
            <div>
                <label>Quantity:</label>
                <input
                    type="number"
                    name="quantity"
                    value={formData.quantity}
                    onChange={handleChange}
                    min="1"
                    required
                />
                {errors.quantity && <span>{errors.quantity}</span>}
            </div>
            <button type="submit">Add Vegetable</button>
        </form>
    );
};

export default VegetableInsertForm;
