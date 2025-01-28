import { createBrowserRouter, RouterProvider, Navigate } from 'react-router-dom'
import { useEffect, useState } from 'react';
import Layout from './components/pages/Layout';
import NotFound from './components/pages/NotFound';
import Home from './components/pages/Home';
import Register from './components/pages/Register';
import Dashboard from './components/pages/Dashboard';
import Login from './components/pages/Login';
import './App.css';

function PrivateRoute({ element }: { element: JSX.Element }) {
    const token = localStorage.getItem("token");
    return token ? element : <Navigate to="/login" replace />;
}

function App() {
    const router = createBrowserRouter([
        {
            path: "/",
            element: <Layout />,
            errorElement: <NotFound />,
            children: [
                { path: "/", element: <Home /> },
                { path: "/login", element: <Login /> },
                { path: "/register", element: <Register /> },
                { path: "/dashboard", element: <PrivateRoute element={<Dashboard />} /> }
            ]
        }
    ]);

    return <RouterProvider router={router} />;
}


export default App;
