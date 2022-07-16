import { Add, Delete, Remove } from "@mui/icons-material";
import { Box, IconButton, Paper, Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Typography } from "@mui/material";
import { useState } from "react";
import agent from "../../app/api/agent";
import { useStoreContext } from "../../app/context/StoreContext";

export default function BasketPage() {
    const {basket, setBasket, removeItem} = useStoreContext();
    const[loading, setLoading] = useState(false);
    
    function handleAddItem(bookId: number) {
        setLoading(true);
        agent.Basket.addItem(bookId)
            .then(basket => setBasket(basket))
            .catch(error => console.log(error))
            
    }

    if (!basket) {
        return <Typography>Your cart is empty</Typography>;
    }
    
    return (
        <TableContainer component={Paper}>
            <Table sx={{ minWidth: 650 }}>
                <TableHead>
                    <TableRow>
                        <TableCell>Book</TableCell>
                        <TableCell align="right">Price</TableCell>
                        <TableCell align="center">Quantity</TableCell>
                        <TableCell align="right">Subtotal</TableCell>
                        <TableCell align="right"></TableCell>
                    </TableRow>
                </TableHead>
                <TableBody>
                    {basket.items.map(item => (
                        <TableRow
                            key={item.bookId}
                            sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
                        >
                            <TableCell component="th" scope="row">
                                <Box display='flex' alignItems='center'>
                                    <img src={item.coverUrl} alt={item.title} style={{height: 50, marginRight: 20}}/>
                                    <span>{item.title}</span>
                                </Box>
                            </TableCell>
                            <TableCell align="right">円{item.price}</TableCell>
                            <TableCell align="center"> 
                                <IconButton color='error'>
                                    <Remove />
                                </IconButton>
                                {item.quantity}
                                <IconButton color='error'>
                                    <Add />
                                </IconButton>
                            </TableCell>
                            <TableCell align="right">円{item.price * item.quantity}</TableCell>
                            <TableCell align="right">
                                <IconButton color='error'>
                                    <Delete />
                                </IconButton>
                            </TableCell>
                        </TableRow>
                    ))}
                </TableBody>
            </Table>
        </TableContainer>
    )
}
