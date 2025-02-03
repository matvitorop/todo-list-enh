import { useState } from "react";
import { ToggleButton, ToggleButtonGroup, Box } from "@mui/material";
import FormA from "../components/reusable-items/activities/FormA";
import FormB from "../components/reusable-items/activities/FormB";
import { TaskFormData, GoalFormData } from "../interfaces/ActivityInterfaces";
const API_URL = "https://localhost:7289";

const ToggleForms: React.FC = () => {
    const [form, setForm] = useState<"a" | "b">("a");

    //const handleFormSubmit = (data: TaskFormData | GoalFormData) => {
    //    console.log("Form was sent:", data);
    //};
    const handleFormSubmit = async (data: TaskFormData | GoalFormData, type: "task" | "goal") => {
        const token = localStorage.getItem("token");

        let endpoint = "";

        if (type === "task") {
            endpoint = data.scope === "week" ? `${API_URL}/Week/addTask` : `${API_URL}/Day/addTask`;
        } else if (type === "goal") {
            endpoint = data.scope === "week" ? `${API_URL}/Week/addGoal` : `${API_URL}/Day/addGoal`;
        }

        const { scope, ...dataWithoutScope } = data;

        try {
            const response = await fetch(endpoint, {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                    "Authorization": `Bearer ${token}`,
                },
                body: JSON.stringify(dataWithoutScope),
            });

            if (!response.ok) {
                throw new Error("Failed to save " + type);
            }

            console.log(`${type} saved successfully`);
        } catch (error) {
            console.error("Error:", error);
        }
        console.log("Form was sent:", token);
    };

    return (
        <Box>
            <ToggleButtonGroup
                value={form}
                exclusive
                onChange={(_, value) => value && setForm(value)}
            >
                <ToggleButton value="a">Tasks</ToggleButton>
                <ToggleButton value="b">Goals</ToggleButton>
            </ToggleButtonGroup>

            <Box mt={2}>
                {form === "a" ? <FormA onSubmit={handleFormSubmit} /> : <FormB onSubmit={handleFormSubmit} />}
            </Box>
        </Box>
    );
};

export default ToggleForms;
