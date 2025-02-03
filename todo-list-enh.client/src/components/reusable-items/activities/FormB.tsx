import { useForm, Controller } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import { Box, Paper, Typography, Button, MenuItem, Select, FormControl, InputLabel } from "@mui/material";
import { goalSchema } from "./ValidationSchemas";
import { GoalFormData } from "../../../interfaces/ActivityInterfaces";
import { useUserStore } from "../../state-manager/useStore";
import FormInput from "../../reusable-items/FormInput";

interface FormBProps {
    onSubmit: (data: GoalFormData) => void;
}

const FormB: React.FC<{ onSubmit: (data: GoalFormData, type: "goal") => void }> = ({ onSubmit }) => {
    const { user } = useUserStore();

    const { control, handleSubmit, formState: { errors } } = useForm({
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
            scope: data.scope,
        };
        onSubmit(formattedData, "goal");
    };

    return (
        <Box component={Paper} p={3} elevation={3}>
            <Typography variant="h6">Add new Goal</Typography>
            <form onSubmit={handleSubmit(submitHandler)}>
                <FormInput
                    name="title"
                    control={control}
                    label="Title"
                    errors={errors}
                />
                <FormInput
                    name="description"
                    control={control}
                    label="Description"
                    errors={errors}
                />
                {/*<FormControlLabel control={<Checkbox {...control.register("isTemplate")} />} label="Template" />*/}
                <FormControl fullWidth margin="normal">
                    <InputLabel>Scope</InputLabel>
                    <Controller
                        name="scope"
                        control={control}
                        defaultValue="week"
                        render={({ field }) => (
                            <Select {...field} label="Scope">
                                <MenuItem value="week">Week</MenuItem>
                                <MenuItem value="day">Day</MenuItem>
                            </Select>
                        )}
                    />
                </FormControl>
                <Button type="submit" variant="contained" color="secondary">Add</Button>
            </form>
        </Box>
    );
};

export default FormB;