import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import Login from './pages/Login';
import Registration from './pages/Registration';
import AdminPage from './pages/adminPage'; 
import AddVegetableForm from './pages/VegetableAddForm';
import DeleteVegetableForm from './pages/DeleteVegetableForm';
import UpdateVegetableForm from './pages/UpdateVegetableForm';
import Shop from './pages/Shop'; 
import Navbar from './Components/Navbar';
import Home from './pages/Home';
import Cart from './pages/Cart';
import AdminDashboard from './pages/AdminDashboard';

const App = () => {
    return (
        <Router>
            <Routes>
                <Route path="/" element={<Home />} />
                <Route path="/navbar" element={<Navbar />} />
                <Route path="/login" element={<Login />} />
                <Route path="/register" element={<Registration />} />
                <Route path="/admin-page" element={<AdminPage />} />
                <Route path="/add-vegetable" element={<AddVegetableForm />} />
                <Route path="/delete-vegetable" element={<DeleteVegetableForm />} />
                <Route path="/update-vegetable" element={<UpdateVegetableForm />} />
                <Route path="/shop" element={<Shop />} />
                <Route path="/cart" element={<Cart />} />
                <Route path="/admin" element={<AdminDashboard />} /> 
            </Routes>
        </Router>
    );
};

export default App;
