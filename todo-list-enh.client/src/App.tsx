import { createBrowserRouter, RouterProvider } from 'react-router-dom'
import { useEffect, useState } from 'react';
import Layout from './components/pages/Layout';
import NotFound from './components/pages/NotFound';
import Home from './components/pages/Home';
import './App.css';

function App() {
   
    const router = createBrowserRouter([
        {
            path: "/",
            element: <Layout />,
            errorElement: <NotFound />,
            children: [
                {
                    path: '/',
                    element: <Home/>
                }
            ]
        }
    ])

    return (
        <>
            <RouterProvider router={router} />
        </>
    );
}

export default App;
