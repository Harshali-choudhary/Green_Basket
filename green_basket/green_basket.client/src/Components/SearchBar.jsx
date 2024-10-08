/* eslint-disable react/prop-types */
/* eslint-disable no-unused-vars */
// SearchBar.jsx
import React, { useState } from 'react';
import './SearchBar.css';

const SearchBar = ({ onSearch }) => {
    const [query, setQuery] = useState('');

    const handleChange = (e) => {
        setQuery(e.target.value);
        onSearch(e.target.value);
    };

    return (
        <div className="search-bar">
            <input
                type="text"
                value={query}
                onChange={handleChange}
                placeholder="Search products..."
            />
        </div>
    );
};

export default SearchBar;
