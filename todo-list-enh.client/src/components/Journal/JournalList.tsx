import React from "react";
import { useJournals } from "../../hooks/useJournals/useJournalList";

const JournalList: React.FC = () => {
    const { journals, loading, error, handleDelete } = useJournals();

    if (loading) return <div>Завантаження...</div>;
    if (error) return <div>Помилка: {error}</div>;

    return (
        <div>
            <h1>Мої журнали</h1>
            <ul>
                {journals.map((journal) => (
                    <li key={journal.id}>
                        {journal.title}
                        <button onClick={() => handleDelete(journal.id.toString())}>Видалити</button>
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default JournalList;
