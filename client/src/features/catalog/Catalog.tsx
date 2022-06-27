import { useEffect, useState } from "react";
import agent from "../../app/api/agent";
import { Book } from "../../app/models/book";
import BookList from "./BookList";

export default function Catalog() {

    const [books, setBooks] = useState<Book[]>([]);

    useEffect(() => {
        agent.Catalog.list().then(books => setBooks(books))
    }, []);

    return (
        <>
            <BookList books={books}></BookList>
        </>
    )
}