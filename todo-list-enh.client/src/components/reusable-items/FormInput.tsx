import { useNavigate } from "react-router-dom";
import { useForm, Controller } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
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