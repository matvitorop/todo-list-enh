import { Outlet } from "react-router-dom";

export default function Layout() {
    return (
        <div>
            <header style={{ backgroundColor: '#333', padding: '10px', color: '#fff', textAlign: 'center' }}>
                <h1>My Application</h1>
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