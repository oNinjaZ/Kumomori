import { Button } from "@mui/material";
import { Book } from "../../app/models/book";
import BookList from "./BookList";

interface Props {
    books: Book[];
    addBook: () => void;
}

export default function Catalog({books, addBook}: Props) {
    return (
        <>
            <BookList books={books}></BookList>
            <Button variant='outlined' onClick={addBook}>Add book</Button>
        </>
    )
}