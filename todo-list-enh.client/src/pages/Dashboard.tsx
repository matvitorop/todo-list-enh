import JournalList from "../components/Journal/JournalList";
export default function Dashboard() {
    return (
        <div>
            <div>
                <h1 id="tableLabel">Closed page</h1>
                <p>Only for cool guys</p>
            </div>
            <div>
                <JournalList />
            </div>
            
        </div>
    )
}