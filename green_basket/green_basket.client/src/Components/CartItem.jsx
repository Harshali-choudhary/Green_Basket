// eslint-disable-next-line no-unused-vars
import React from 'react';
import PropTypes from 'prop-types';
import './cartItem.css';

const CartItem = ({ item, onRemove }) => {
    return (
        <div className="cart-item">
            <img src={item.image_url} alt={item.vegetable_name} className="cart-item-image" />
            <div className="cart-item-details">
                <h3 className="cart-item-name">{item.vegetable_name}</h3>
                <p className="cart-item-price">${item.vegetable_price.toFixed(2)}</p>
                <p className="cart-item-quantity">Quantity: {item.quantity}</p>
                <button className="remove-from-cart" onClick={() => onRemove(item.vegetable_id)}>Remove</button>
            </div>
        </div>
    );
};

CartItem.propTypes = {
    item: PropTypes.shape({
        vegetable_id: PropTypes.number.isRequired,
        image_url: PropTypes.string.isRequired,
        vegetable_name: PropTypes.string.isRequired,
        vegetable_price: PropTypes.number.isRequired,
        quantity: PropTypes.number.isRequired,
    }).isRequired,
    onRemove: PropTypes.func.isRequired,
};

export default CartItem;
