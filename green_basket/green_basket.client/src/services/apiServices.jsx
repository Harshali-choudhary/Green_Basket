// src/services/apiService.js

export const fetchUsers = async () => {
    try {
        const response = await fetch('/api/Users');
        if (!response.ok) {
            throw new Error('Failed to fetch Users');
        }
        return await response.json();
    } catch (error) {
        console.error('Error fetching Users:', error);
        throw error;
    }
};

export const fetchVegetables = async () => {
    try {
        const response = await fetch('/api/Vegetable');
        if (!response.ok) {
            throw new Error('Failed to fetch Vegetables');
        }
        return await response.json();
    } catch (error) {
        console.error('Error fetching Vegetables:', error);
        throw error;
    }
};

export const fetchOrders = async () => {
    try {
        const response = await fetch('/api/Orders');
        if (!response.ok) {
            throw new Error('Failed to fetch Orders');
        }
        return await response.json();
    } catch (error) {
        console.error('Error fetching Orders:', error);
        throw error;
    }
};

export const fetchFeedback = async () => {
    try {
        const response = await fetch('/api/Feedback');
        if (!response.ok) {
            throw new Error('Failed to fetch Feedback');
        }
        return await response.json();
    } catch (error) {
        console.error('Error fetching Feedback:', error);
        throw error;
    }
};

export const fetchCurrentUserSession = async () => {
    try {
        const response = await fetch('/api/CurrentUserSession');
        if (!response.ok) {
            throw new Error('Failed to fetch CurrentUserSession');
        }
        return await response.json();
    } catch (error) {
        console.error('Error fetching CurrentUserSession:', error);
        throw error;
    }
};

export const fetchCartVegetables = async () => {
    try {
        const response = await fetch('/api/CartVegetable');
        if (!response.ok) {
            throw new Error('Failed to fetch CartVegetables');
        }
        return await response.json();
    } catch (error) {
        console.error('Error fetching CartVegetables:', error);
        throw error;
    }
};

export const fetchBillDetails = async () => {
    try {
        const response = await fetch('/api/BillDetails');
        if (!response.ok) {
            throw new Error('Failed to fetch BillDetails');
        }
        return await response.json();
    } catch (error) {
        console.error('Error fetching BillDetails:', error);
        throw error;
    }
};

export const fetchCartOrders = async () => {
    try {
        const response = await fetch('/api/CartOrder');
        if (!response.ok) {
            throw new Error('Failed to fetch CartOrder');
        }
        return await response.json();
    } catch (error) {
        console.error('Error fetching CartOrder:', error);
        throw error;
    }
};


