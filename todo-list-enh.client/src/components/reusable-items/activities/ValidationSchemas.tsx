import * as yup from "yup";

export const taskSchema = yup.object().shape({
    title: yup.string().required("Title is required").max(100, "Text is over limit (100)"),
    description: yup.string().max(500, "Text is overlimit (500)"),
    startTime: yup.string().required("Strat time is required"),
    endTime: yup.string().required("End time is required"),
    isStrict: yup.boolean(),
});

export const goalSchema = yup.object().shape({
    title: yup.string().required("Title is required").max(100, "Text is over limit (100)"),
    description: yup.string().max(500, "Text is overlimit (500)"),
    isTemplate: yup.boolean(),
})