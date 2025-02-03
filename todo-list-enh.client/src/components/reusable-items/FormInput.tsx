import { Controller } from "react-hook-form";
import { TextField} from "@mui/material";

interface FormInputProps {
    name: string;
    control: any;
    label: string;
    type?: string;
    errors: any;
}

export default function FormInput({ name, control, label, type = "text", errors }: FormInputProps) {
    return (
        <Controller
            name={name}
            control={control}
            defaultValue=""
            render={({ field }) => (
                <TextField
                    {...field}
                    label={label}
                    type={type}
                    fullWidth
                    margin="normal"
                    error={!!errors[name]}
                    helperText={errors[name]?.message}
                />
            )}
        />
    );
}