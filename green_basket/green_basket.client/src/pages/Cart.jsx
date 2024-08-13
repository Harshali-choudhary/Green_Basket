import React, { useState } from 'react';
import CartItem from '../Components/CartItem';
import './cart.css';

const Cart = () => {
    const [cartItems, setCartItems] = useState([]);

    const handleRemove = (id) => {
        setCartItems(cartItems.filter(item => item.id !== id));
    };

    return (
        <div className="cart">
            <h1>Your Cart</h1>
            {cartItems.length === 0 ? (
                <p>Your cart is currently empty.</p>
            ) : (
                <div className="cart-items">
                    {cartItems.map(item => (
                        <CartItem key={item.id} item={item} onRemove={handleRemove} />
                    ))}
                </div>
            )}
        </div>
    );
};

export default Cart;
