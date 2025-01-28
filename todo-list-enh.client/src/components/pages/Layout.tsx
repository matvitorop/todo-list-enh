import { Link, useNavigate, Outlet } from "react-router-dom";
import { useEffect, useState } from "react";

export default function Layout() {
    const [username, setUsername] = useState<string | null>(null);
    const navigate = useNavigate();

    useEffect(() => {
        const storedUsername = localStorage.getItem("username");
        if (storedUsername) {
            setUsername(storedUsername);
        }
    }, []);

    const handleLogout = () => {
        localStorage.removeItem("token");
        localStorage.removeItem("username");
        setUsername(null);
        navigate("/login");
    };

    return (
        <div>
            <header style={{ backgroundColor: '#333', padding: '10px', color: '#fff', textAlign: 'center' }}>
                <nav style={{ display: "flex", justifyContent: "space-between", padding: "10px", background: "#282c34", color: "white" }}>
                    <Link to="/" style={{ color: "white", textDecoration: "none" }}>Main</Link>
                    {username ? (
                        <div>
                            <span>{localStorage.getItem("username")}</span>
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
