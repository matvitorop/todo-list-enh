export interface AddTask {
    userId?: number;
    title: string;
    description?: string;
    isStrict: boolean;
    isCompleted: boolean;
    isTemplate: boolean;
    startTime: string;
    endTime: string;
}

export interface AddGoal {
    userId?: number;
    title: string;
    description?: string;
    isCompleted: boolean;
    isTemplate: boolean;
    createdAt: string;
}

export interface TaskFormData {
    addTask: AddTask;
    activityId: number;
    order: number;
}

export interface GoalFormData {
    addGoal: AddGoal;
    activityId: number;
}