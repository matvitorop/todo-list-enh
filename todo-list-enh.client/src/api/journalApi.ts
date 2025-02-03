import api from './axiosInstance';
import { JournalDTO, AddJournalDTO } from '../interfaces/JournalInterfaces';

export const journalApi = {
    async getMyJournals(): Promise<JournalDTO[]> {
        const { data } = await api.get("/Journals/my");
        return data;
    },

    async getJournalDetails(journalId: string): Promise<JournalDTO> {
        const { data } = await api.get(`/Journal/deteils/${journalId}`);
        return data;
    },

    async addJournal(journal: AddJournalDTO): Promise<JournalDTO> {
        const { data } = await api.post("/Journals", journal);
        return data;
    },

    async deleteJournal(journalId: string): Promise<void> {
        await api.delete(`/Journals/${journalId}`);
    }
};