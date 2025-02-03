import { create } from 'zustand';
import { journalApi } from '../api/journalApi';
import { JournalDTO, AddJournalDTO } from '../interfaces/JournalInterfaces';

interface JournalState {
    journals: JournalDTO[];
    loading: boolean;
    error: string | null;
    fetchJournals: () => Promise<void>;
    addJournal: (journal: AddJournalDTO) => Promise<void>;
    deleteJournal: (journalId: string) => Promise<void>;
    setJournals: (journals: JournalDTO[]) => void;
    setLoading: (loading: boolean) => void;
    setError: (error: string) => void;
}

export const useJournalStore = create<JournalState>((set) => ({
    journals: [],
    loading: false,
    error: null,
    fetchJournals: async () => {
        set({ loading: true, error: null });
        try {
            const data = await journalApi.getMyJournals();
            set({ journals: data });
        } catch (error) {
            set({ error: "Помилка при завантаженні журналів" });
        } finally {
            set({ loading: false });
        }
    },
    addJournal: async (journal) => {
        set({ loading: true, error: null });
        try {
            const newJournal = await journalApi.addJournal(journal);
            set((state) => ({
                journals: [...state.journals, newJournal],
            }));
        } catch (error) {
            set({ error: "Помилка при додаванні журналу" });
        } finally {
            set({ loading: false });
        }
    },
    deleteJournal: async (journalId) => {
        set({ loading: true, error: null });
        try {
            await journalApi.deleteJournal(journalId);
            set((state) => ({
                journals: state.journals.filter((journal) => journal.id.toString() !== journalId),
            }));
        } catch (error) {
            set({ error: "Помилка при видаленні журналу" });
        } finally {
            set({ loading: false });
        }
    },
    setJournals: (journals) => set({ journals }),
    setLoading: (loading) => set({ loading }),
    setError: (error) => set({ error }),
}));
