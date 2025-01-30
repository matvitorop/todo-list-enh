import { useNavigate } from "react-router-dom";
import { useForm, Controller } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import { TextField, Button, Container, Typography, Alert, Box } from "@mui/material";
import FormInput from "../reusable-items/FormInput"

const schema = yup.object().shape({
    email: yup.string().email("Invalid email format").required("Email is required"),
    password: yup.string().min(6, "Password must be at least 6 characters").required("Password is required"),
});

export default function Login() {
    const navigate = useNavigate();
    const {
        control,
        handleSubmit,
        setError,
        formState: { errors },
    } = useForm({
        resolver: yupResolver(schema),
    });

    const onSubmit = async (data) => {
        try {
            const response = await fetch("https://localhost:7289/Users/login", {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify({
                    username: "undefined",
                    email: data.email,
                    password: data.password,
                    createdAt: new Date().toISOString(),
                }),
            });

            if (!response.ok) {
                throw new Error("Wrong email or password.");
            }

            const responseData = await response.json();
            localStorage.setItem("token", responseData.token);
            localStorage.setItem("user", JSON.stringify(responseData.user));
            navigate("/dashboard");
        } catch (err) {
            setError("email", { type: "manual", message: "Wrong email or password." });
        }
    };

    return (
        <Container maxWidth="xs">
            <Box display="flex" flexDirection="column" alignItems="center" mt={10}>
                <Typography variant="h4" gutterBottom>
                    Log in
                </Typography>
                <form onSubmit={handleSubmit(onSubmit)} style={{ width: "100%" }}>
                    <FormInput name="email" control={control} label="Email" errors={errors} />
                    <FormInput name="password" control={control} label="Password" type="password" errors={errors} />
                    {errors.email && <Alert severity="error">{errors.email.message}</Alert>}
                    <Button type="submit" variant="contained" color="primary" fullWidth sx={{ mt: 2 }}>
                        Confirm
                    </Button>
                </form>
                <Typography variant="body2" mt={2}>
                    Create an account <a href="/register">Register</a>
                </Typography>
            </Box>
        </Container>
    );
}
