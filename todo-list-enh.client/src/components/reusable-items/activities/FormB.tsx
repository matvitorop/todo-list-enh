import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import { Box, Paper, Typography, TextField, Button, Checkbox, FormControlLabel } from "@mui/material";
import { goalSchema } from "./ValidationSchemas";
import { GoalFormData } from "../../../interfaces/ActivityInterfaces";
import { useUserStore } from "../../state-manager/useStore";

interface FormBProps {
    onSubmit: (data: GoalFormData) => void;
}

const FormB: React.FC<FormBProps> = ({ onSubmit }) => {
    const { user } = useUserStore();

    const { register, handleSubmit, formState: { errors } } = useForm({
        resolver: yupResolver(goalSchema),
    });

    const submitHandler = (data: any) => {
        const formattedData: GoalFormData = {
            addGoal: {
                userId: user?.id,
                title: data.title,
                description: data.description || "",
                isCompleted: false,
                isTemplate: data.isTemplate || false,
                createdAt: new Date().toISOString(),
            },
            activityId: 1,
        };
        onSubmit(formattedData);
    };

    return (
        <Box component={Paper} p={3} elevation={3}>
            <Typography variant="h6">Нова ціль</Typography>
            <form onSubmit={handleSubmit(submitHandler)}>
                <TextField label="Назва" fullWidth margin="normal" {...register("title")} error={!!errors.title} helperText={errors.title?.message} />
                <TextField label="Опис" fullWidth margin="normal" {...register("description")} error={!!errors.description} helperText={errors.description?.message} />
                <FormControlLabel control={<Checkbox {...register("isTemplate")} />} label="Шаблон" />
                <Button type="submit" variant="contained" color="secondary">Зберегти</Button>
            </form>
        </Box>
    );
};

export default FormB;