import { Link } from "react-router-dom";
import styles from "./../styles/Home.module.css";

export default function NotFound() {
    return (
        <div style={{ textAlign: 'center', marginTop: '50px' }}>
            <h1>404 - Not Found. Тобі тут не місце, сталкере</h1>
            <Link to="/" className={styles.link}>
                Повернутися на головну
            </Link>
        </div>
    );
}