import React from 'react';
import { Link } from 'react-router-dom';
import './navbar.css'; // Make sure you have a corresponding CSS file for styling

const Navbar = () => {
    return (
        <nav className="navbar">
            <div className="navbar-container">
                <h1 className="navbar-logo">
                    <Link to="/">Green Basket</Link>
                </h1>
                <ul className="navbar-menu">
                    <li className="navbar-item">
                        <Link to="/" className="navbar-link">Home</Link>
                    </li>
                    <li className="navbar-item">
                        <Link to="/shop" className="navbar-link">Shop</Link>
                    </li>
                    <li className="navbar-item">
                        <Link to="/cart" className="navbar-link">Cart</Link>
                    </li>
                    <li className="navbar-item">
                        <Link to="/login" className="navbar-link">Login</Link>
                    </li>
                    <li className="navbar-item">
                        <Link to="/registration" className="navbar-link">Register</Link>
                    </li>
                </ul>
            </div>
        </nav>
    );
};

export default Navbar;
