import { Book } from "../../app/models/book";

interface Props {
    books: Book[];
    addBook: () => void;
}

export default function Catalog({books, addBook}: Props) {
    return (
        <>
            <ul>
                {books.map(book =>
                    <li key={book.id}>{book.title} - {book.author}</li>
                )}
            </ul>
            <button onClick={addBook}>Add book</button>
        </>
    )
}