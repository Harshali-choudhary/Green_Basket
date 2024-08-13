// SearchBar.jsx
import React, { useState } from 'react';
import './searchBar.css';

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
