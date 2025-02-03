import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import { Box, Paper, Typography, Button, Checkbox, FormControlLabel } from "@mui/material";
import { taskSchema } from "./ValidationSchemas";
import { TaskFormData } from "../../../interfaces/ActivityInterfaces";
import { useUserStore } from "../../state-manager/useStore";
import FormInput from "../../reusable-items/FormInput";
interface FormAProps {
    onSubmit: (data: TaskFormData) => void;
}

const FormA: React.FC<FormAProps> = ({ onSubmit }) => {
    const { user } = useUserStore();

    const { control, handleSubmit, formState: { errors } } = useForm({
        resolver: yupResolver(taskSchema),
    });

    const submitHandler = (data: any) => {
        const formattedData: TaskFormData = {
            addTask: {
                userId: user?.id,
                title: data.title,
                description: data.description || "",
                isStrict: data.isStrict || false,
                isCompleted: false,
                isTemplate: false,
                startTime: data.startTime,
                endTime: data.endTime,
            },
            activityId: 1,
            order: 1,
        };
        onSubmit(formattedData);
    };

    return (
        <Box component={Paper} p={3} elevation={3}>
            <Typography variant="h6">Add new Task</Typography>
            <form onSubmit={handleSubmit(submitHandler)}>
                <FormInput
                    name="title"
                    control={control}
                    label="Назва"
                    errors={errors}
                />
                <FormInput
                    name="description"
                    control={control}
                    label="Опис"
                    errors={errors}
                />
                <FormInput
                    name="startTime"
                    control={control}
                    label="Час початку"
                    type="time"
                    errors={errors}
                />
                <FormInput
                    name="endTime"
                    control={control}
                    label="Час завершення"
                    type="time"
                    errors={errors}
                />
                <FormControlLabel control={<Checkbox {...register("isStrict")} />} label="Strict mode" />
                <Button type="submit" variant="contained" color="primary">Add</Button>
            </form>
        </Box>
    );
};

export default FormA;
