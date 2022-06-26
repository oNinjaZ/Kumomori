import { Divider, Grid, Table, TableBody, TableCell, TableContainer, TableRow, Typography } from "@mui/material";
import axios from "axios";
import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { Book } from "../../app/models/book";

export default function BookDetails() {

    const { id } = useParams<{ id: string }>();
    const [book, setBook] = useState<Book | null>(null);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        axios.get(`http://localhost:5000/api/books/${id}`)
            .then(resp => setBook(resp.data))
            .catch(error => console.log(error))
            .finally(() => setLoading(false))
    }, [id])

    if (loading) return <h1>Loading...</h1>

    if (!book) return <h3>Not Found...</h3>

    const publishDate = new Date(book.publishDate).toLocaleDateString('en-us', { year: 'numeric', month: 'numeric', day: 'numeric' })

    return (
        <Grid container spacing={6}>
            <Grid item xs={3}>
                <img src={book.coverUrl} alt={book.title} style={{ width: '100%' }} />
            </Grid>

            <Grid item xs={9}>
                <Typography variant='h4'>{book.title}</Typography>
                <Divider sx={{ mb: 2 }} />
                <Typography variant='h5' color='secondary'>{book.price}¥</Typography>
                <TableContainer sx={{mt: 2}}>
                    <Table>
                        <TableBody>
                            <TableRow>
                                <TableCell>Type</TableCell>
                                <TableCell>{book.type}</TableCell>
                            </TableRow>
                            <TableRow>
                                <TableCell>Author</TableCell>
                                <TableCell>{book.author}</TableCell>
                            </TableRow>
                            <TableRow>
                                <TableCell>Description</TableCell>
                                <TableCell>{book.description}</TableCell>
                            </TableRow>
                            <TableRow>
                                <TableCell>Pages</TableCell>
                                <TableCell>{book.pageCount}</TableCell>
                            </TableRow>
                            <TableRow>
                                <TableCell>Release</TableCell>
                                <TableCell>{publishDate}</TableCell>
                            </TableRow>
                            <TableRow>
                                <TableCell>Quantity</TableCell>
                                <TableCell>{book.quantityInStock}</TableCell>
                            </TableRow>
                        </TableBody>
                    </Table>
                </TableContainer>
            </Grid>
        </Grid>
    )
}