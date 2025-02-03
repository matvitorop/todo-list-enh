import React from "react";
import { useJournals } from "../../hooks/useJournals/useJournalList";

const JournalList: React.FC = () => {
    const { journals, loading, error, handleDelete } = useJournals();

    if (loading) return <div>Loading...</div>;
    if (error) return <div>Error: {error}</div>;

    return (
        <div>
            <h2>Journals</h2>
            <ul>
                {journals.map((journal) => (
                    <li key={journal.id}>
                        {journal.title}
                        <button onClick={() => handleDelete(journal.id.toString())}>Delete</button>
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default JournalList;
