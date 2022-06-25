import { useEffect, useState } from "react";
import { Book } from "../../app/models/book";
import BookList from "./BookList";

export default function Catalog() {

    const [books, setBooks] = useState<Book[]>([]);

    useEffect(() => {
        fetch('http://localhost:5000/api/books')
            .then(res => res.json())
            .then(data => setBooks(data));
    }, []);

    return (
        <>
            <BookList books={books}></BookList>
        </>
    )
}