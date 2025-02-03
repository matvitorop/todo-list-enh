import { useNavigate } from "react-router-dom";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import { Button, Container, Typography, Alert, Box } from "@mui/material";
import FormInput from "../components/reusable-items/FormInput";

import { AuthRequest } from "../Interfaces/UserInterfaces";

import { loginUser } from "../components/reusable-items/AuthController";
import { useUserStore } from "../components/state-manager/useStore";

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

    const onSubmit = async (data : AuthRequest ) => {
        try {
            const responseData = await loginUser(data.email, data.password);
            localStorage.setItem("token", responseData.token);
            localStorage.setItem("user", JSON.stringify(responseData.user));

            useUserStore.getState().setUser(responseData.user);

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
