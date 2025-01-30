import { Link, Outlet } from "react-router-dom";
import { useUserStore } from "../state-manager/useStore";


export default function Layout() {
    const { user, logout } = useUserStore();

    return (
        <div>
            <header style={{ backgroundColor: '#333', padding: '10px', color: '#fff', textAlign: 'center' }}>
                <nav style={{ display: "flex", justifyContent: "space-between", padding: "10px", background: "#282c34", color: "white" }}>
                    <Link to="/" style={{ color: "white", textDecoration: "none" }}>Main</Link>
                    {user ? (
                        <div>
                            <span>{user.username}</span>
                            <button onClick={logout} style={{ marginLeft: "10px" }}>Logout</button>
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

