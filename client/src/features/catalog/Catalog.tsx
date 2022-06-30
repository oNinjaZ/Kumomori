import { useEffect, useState } from "react";
import agent from "../../app/api/agent";
import LoadingComponent from "../../app/layout/LoadingComponent";
import { Book } from "../../app/models/book";
import BookList from "./BookList";

export default function Catalog() {

    const [books, setBooks] = useState<Book[]>([]);

    const [loading, setLoading] = useState(true);

    useEffect(() => {
        agent.Catalog.list()
        .then(books => setBooks(books))
        .catch(error => console.log(error))
        .finally(() => setLoading(false));
    }, []);

    if (loading) return <LoadingComponent message='Loading books...'/>

    return (
        <>
            <BookList books={books}></BookList>
        </>
    )
}