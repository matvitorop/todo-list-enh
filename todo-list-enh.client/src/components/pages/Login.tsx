import { useState } from "react";
import { useNavigate } from "react-router-dom";

export default function Login() {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [error, setError] = useState("");
    const navigate = useNavigate();

    const handleLogin = async (e: React.FormEvent) => {
        e.preventDefault();
        setError("");

        try {
            const response = await fetch("https://localhost:7289/Users/login", {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify({
                    "username": "undefined",
                    "email": email,
                    "password": password,
                    "createdAt": new Date().toISOString()
                })
            });

            if (!response.ok) {
                throw new Error("Wrong email or password.");
            }

            const data = await response.json();
            localStorage.setItem("token", data.token);
            localStorage.setItem("username", data.username);
            navigate("/dashboard");

        } catch (err) {
            setError("Wrong email or password.");
        }
    };

    return (
        <div style={{ display: "flex", justifyContent: "center", alignItems: "center", height: "100vh" }}>
            <form onSubmit={handleLogin} style={{ display: "flex", flexDirection: "column", width: "300px" }}>
                <h2>Log in</h2>
                {error && <p style={{ color: "red" }}>{error}</p>}
                <input type="email" placeholder="Email" value={email} onChange={(e) => setEmail(e.target.value)} required />
                <input type="password" placeholder="Password" value={password} onChange={(e) => setPassword(e.target.value)} required />
                <button type="submit">Confirm</button>
                <p>Create an account <a href="/register">Register</a></p>
            </form>
        </div>
    );
}