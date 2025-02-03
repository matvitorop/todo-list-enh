import { Box, Paper, Typography } from "@mui/material";
import ToggleForms from "./ToggleForms";

const TasksPanel: React.FC = () => {
    return (
        <Box component={Paper} p={3} elevation={3} sx={{ width: "300px", position: "absolute", left: "20px", top: "100px" }}>
            <Typography variant="h6">Activity List</Typography>
            <ToggleForms />
        </Box>
    );
};

export default TasksPanel;