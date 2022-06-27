import { Container, Typography, Paper, Divider, Button } from "@mui/material";
import { Link } from "react-router-dom";

export default function NotFound() {
    return (
        <Container component={Paper} sx={{height: 400}}>
            <Typography variant='h3' gutterBottom>Oops - we could not find what you are looking for...</Typography>
            <Divider />
            <Button component={Link} to='/catalog'>Go back to the store</Button>
        </Container>
    );
}