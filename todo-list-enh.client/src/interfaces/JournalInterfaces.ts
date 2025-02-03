export interface JournalDTO {
    id: number;
    userId: number;
    title: string;
    description: string;
    createdAt: string;
}

export interface AddJournalDTO {
    title: string;
    description: string;
}