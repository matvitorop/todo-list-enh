import { useEffect } from "react";
import { useJournalStore } from "../../store/journalStore";

export const useJournals = () => {
    const { journals, loading, error, fetchJournals, deleteJournal } = useJournalStore();

    useEffect(() => {
        fetchJournals();
    }, [fetchJournals]);

    const handleDelete = async (journalId: string) => {
        await deleteJournal(journalId);
    };

    return { journals, loading, error, handleDelete };
};
