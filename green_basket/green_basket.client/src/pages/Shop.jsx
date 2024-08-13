import React, { useEffect, useState } from 'react';
import VegetableCard from '../Components/VegetableCard';
import axios from 'axios';

function Shop() {
    const [products, setProducts] = useState([]);

    useEffect(() => {
        axios.get('/api/CartVegetable')
            .then(response => setProducts(response.data))
            .catch(error => console.error('Error fetching products:', error));
    }, []);

    return (
        <div className="shop">
            <h2>Shop</h2>
            <div className="product-list">
                {products.map(product => (
                    <ProductCard key={product.id} product={product} />
                ))}
            </div>
        </div>
    );
}

export default Shop;
