import React, { useEffect, useState } from 'react';
import axios from 'axios';

const Shop = () => {
    const [vegetables, setVegetables] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        const fetchVegetables = async () => {
            try {
                const response = await axios.get('https://localhost:7287/api/Vegetable/GetAllVegetable'); // Updated to match the new API endpoint
                if (response.data.Success) {
                    setVegetables(response.data.Data); // Use the Data property from the response
                } else {
                    setError('Failed to load vegetables.');
                }
            } catch (err) {
                setError('An error occurred while fetching vegetables.');
            } finally {
                setLoading(false);
            }
        };

        fetchVegetables();
    }, []);

    if (loading) return <p>Loading...</p>;
    if (error) return <p>{error}</p>;

    return (
        <div className="shop">
            <h1>Vegetable Shop</h1>
            <div className="vegetable-list">
                {vegetables.length === 0 ? (
                    <p>No vegetables available.</p>
                ) : (
                    vegetables.map((vegetable) => (
                        <div key={vegetable.vegetable_id} className="vegetable-item">
                            <h2>{vegetable.name}</h2>
                            <p>{vegetable.description}</p>
                            <p>Price: ${vegetable.price.toFixed(2)}</p>
                        </div>
                    ))
                )}
            </div>
        </div>
    );
};

export default Shop;
