import React, { useEffect, useState } from 'react';
import axios from 'axios';
import VegetableCard from '../Components/VegetableCard'; // Adjust the path as needed

const VegetableCart = () => {
    const [vegetables, setVegetables] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        const fetchVegetables = async () => {
            try {
                const response = await axios.get('/api/CartVegetable');
                setVegetables(response.data);
                setLoading(false);
            } catch (error) {
                setError('Failed to fetch vegetables.');
                setLoading(false);
            }
        };

        fetchVegetables();
    }, []);

    if (loading) {
        return <p>Loading vegetables...</p>;
    }

    if (error) {
        return <p>{error}</p>;
    }

    return (
        <div className="vegetable-cart">
            <h2>Vegetable Cart</h2>
            <div className="vegetable-list">
                {vegetables.length > 0 ? (
                    vegetables.map(vegetable => (
                        <VegetableCard
                            key={vegetable.id}
                            name={vegetable.name}
                            description={vegetable.description}
                            image={vegetable.imageUrl}
                        />
                    ))
                ) : (
                    <p>No vegetables available.</p>
                )}
            </div>
        </div>
    );
};

export default VegetableCart;
