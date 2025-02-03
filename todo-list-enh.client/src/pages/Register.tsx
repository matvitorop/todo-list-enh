import { useNavigate } from "react-router-dom";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import { Button, Container, Typography, Box, Alert } from "@mui/material";
import { register } from "../components/reusable-items/AuthController";

import { AuthRequest } from "../interfaces/UserInterfaces";

import FormInput from "../components/reusable-items/FormInput";
import { useUserStore } from "../components/state-manager/useStore";

const schema = yup.object().shape({
    username: yup.string().min(3, "Username must be at least 3 characters").required("Username is required"),
    email: yup.string().email("Invalid email format").required("Email is required"),
    password: yup.string().min(6, "Password must be at least 6 characters").required("Password is required"),
});

export default function Register() {
    const navigate = useNavigate();
    const { control, handleSubmit, setError, formState: { errors } } = useForm({
        resolver: yupResolver(schema),
    });

    const onSubmit = async (data: AuthRequest) => {
        try {
            const result = await register(data);
            localStorage.setItem("token", result.token);
            localStorage.setItem("user", JSON.stringify(result.user));

            useUserStore.getState().setUser(result.user);

            navigate("/dashboard");
        } catch (error) {
            setError("root", { message: "Registration failed. The email may already be in use." });
        }
    };

    return (
        <Container maxWidth="xs">
            <Box sx={{ mt: 8, p: 3, borderRadius: 2, boxShadow: 3, textAlign: "center" }}>
                <Typography variant="h5" gutterBottom>Register</Typography>

                {errors.root && <Alert severity="error">{errors.root.message}</Alert>}

                <form onSubmit={handleSubmit(onSubmit)}>
                    <FormInput name="username" control={control} label="Username" errors={errors} />
                    <FormInput name="email" control={control} label="Email" errors={errors} />
                    <FormInput name="password" control={control} label="Password" type="password" errors={errors} />

                    <Button type="submit" variant="contained" color="primary" fullWidth sx={{ mt: 2 }}>
                        Register
                    </Button>
                </form>

                <Typography variant="body2" sx={{ mt: 2 }}>
                    Already have an account? <a href="/login">Login</a>
                </Typography>
            </Box>
        </Container>
    );
}
