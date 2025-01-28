import { useState } from "react";
import { useNavigate } from "react-router-dom";

export default function Register() {
    const [username, setUsername] = useState("");
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [error, setError] = useState("");
    const navigate = useNavigate();

    const handleRegister = async (e: React.FormEvent) => {
        e.preventDefault();
        setError("");

        try {
            const response = await fetch("https://localhost:7289/Users/register", {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify({
                    "username": username,
                    "email": email,
                    "password": password,
                    "createdAt": new Date().getDate
                })
            });

            if (!response.ok) {
                throw new Error("Email is already used");
            }

            const data = await response.json();
            localStorage.setItem("token", data.token);
            localStorage.setItem("username", data.username);
            navigate("/dashboard");

        } catch (err) {
            setError("Registration error");
        }
    };

    return (
        <div style={{ display: "flex", justifyContent: "center", alignItems: "center", height: "100vh" }}>
            <form onSubmit={handleRegister} style={{ display: "flex", flexDirection: "column", width: "300px" }}>
                <h2>Registration</h2>
                {error && <p style={{ color: "red" }}>{error}</p>}
                <input type="text" placeholder="Username" value={username} onChange={(e) => setUsername(e.target.value)} required />
                <input type="email" placeholder="Email" value={email} onChange={(e) => setEmail(e.target.value)} required />
                <input type="password" placeholder="Password" value={password} onChange={(e) => setPassword(e.target.value)} required />
                <button type="submit">Register</button>
                <p>Have an account? <a href="/login">”‚≥ÈÚË</a></p>
            </form>
        </div>
    );
}
