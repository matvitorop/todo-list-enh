import * as yup from "yup";

export const taskSchema = yup.object().shape({
    title: yup.string().required("Title is required").max(100, "Text is over limit (100)"),
    description: yup.string().max(500, "Text is over limit (500)"),
    startTime: yup
        .string()
        .required("Start time is required"),
    endTime: yup
        .string()
        .required("End time is required")
        .test("is-after-start", "End time must be after start time", function (value) {
            const { startTime } = this.parent;
            return startTime && value ? startTime < value : true;
        }),
    isStrict: yup.boolean(),
    scope: yup.string().oneOf(["week", "day"], "Invalid scope").required("Scope is required"),
});


export const goalSchema = yup.object().shape({
    title: yup.string().required("Title is required").max(100, "Text is over limit (100)"),
    description: yup.string().max(500, "Text is overlimit (500)"),
    isTemplate: yup.boolean(),
    scope: yup.string().oneOf(["week", "day"], "Invalid scope").required("Scope is required"),
})