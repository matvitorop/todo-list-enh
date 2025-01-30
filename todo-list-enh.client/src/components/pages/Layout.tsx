import { Link, useNavigate, Outlet } from "react-router-dom";
import { useEffect, useState } from "react";
import { User } from "../Interfaces/UserInterfaces"

export default function Layout() {
    const [user, setUser] = useState<User | null>(null);
    const navigate = useNavigate();

    useEffect(() => {
        const storedUser = localStorage.getItem("user");
        if (storedUser) {
            setUser(JSON.parse(storedUser));
        }
    }, []);

    const handleLogout = () => {
        localStorage.removeItem("token");
        localStorage.removeItem("user");
        setUser(null);
        navigate("/login");
    };

    return (
        <div>
            <header style={{ backgroundColor: '#333', padding: '10px', color: '#fff', textAlign: 'center' }}>
                <nav style={{ display: "flex", justifyContent: "space-between", padding: "10px", background: "#282c34", color: "white" }}>
                    <Link to="/" style={{ color: "white", textDecoration: "none" }}>Main</Link>
                    {user ? (
                        <div>
                            <span>{user.username}</span>  {}
                            <button onClick={handleLogout} style={{ marginLeft: "10px" }}>Logout</button>
                        </div>
                    ) : (
                        <Link to="/login" style={{ color: "white", textDecoration: "none" }}>Log in</Link>
                    )}
                </nav>
            </header>
            <main style={{ padding: '20px', minHeight: '65vh' }}>
                <Outlet />
            </main>
            <footer style={{ backgroundColor: '#333', padding: '10px', color: '#fff', textAlign: 'center' }}>
                <p>© 2024 My Application. All rights reserved.</p>
            </footer>
        </div>
    );
}
