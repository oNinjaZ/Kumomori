import { Container, CssBaseline } from "@mui/material";
import { useEffect, useState } from "react";
import Catalog from "../../features/catalog/Catalog";
import { Book } from "../models/book";
import Header from "./Header";

function App() {
  const [books, setBooks] = useState<Book[]>([]);

  useEffect(() => {
    fetch('http://localhost:5000/api/books')
      .then(res => res.json())
      .then(data => setBooks(data));
  }, []);

  function addBook() {
    setBooks(prevState => [...prevState,
    {
      id: prevState.length + 1,
      author: 'テスト著者',
      title: '本' + (prevState.length + 1),
      description: 'testDescription',
      pageCount: 100,
      price: 10.00,
      coverUrl: 'https://via.placeholder.com/150',
      type: 'testType',
      quantityInStock: 10,
      publishDate: new Date(2020, 1, 1)
    }]);
  }

  return (
    <>
      <CssBaseline></CssBaseline>
      <Header></Header>
      <Container>
        <Catalog books={books} addBook={addBook} />
      </Container>
    </>
  );
}

export default App;
