import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import Navbar from './Components/Navbar';
import Home from './pages/Home';
import Shop from './pages/Shop';
//import ProductDetails from './pages/ProductDetails';
import Login from './pages/Login';
import Registration from './pages/Registration';
import Cart from './pages/Cart';

function App() {
    return (
        <Router>
            <Navbar />
            <Routes>
                <Route path="/" element={<Home />} />
                <Route path="/shop" element={<Shop />} />
               {/* <Route path="//:id" element={<ProductDetails />} />*/}
                <Route path="/login" element={<Login />} />
                <Route path="/registration" element={<Registration />} />
                <Route path="/cart" element={<Cart />} />
            </Routes>
        </Router>
    );
}

export default App;
