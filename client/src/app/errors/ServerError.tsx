import { Button, Container, Divider, Paper, Typography } from "@mui/material";
import { useHistory, useLocation } from "react-router-dom";

interface LocationState {
    error: string;
    title: string;
}

export default function ServerError() {
    const history = useHistory();
    const { state } = useLocation<LocationState>();
    console.log();

    return (
        <Container component={Paper}>
            {state?.error ? (
                <>
                    <Typography variant='h5' color='error' gutterBottom>{state.title}</Typography>
                    <Divider />
                    <Typography>{state.error} || 'Internal Server Error'</Typography>
                </>
            ) : (
                <Typography variant='h5' gutterBottom>Server Error</Typography>
            )}
            <Button onClick={() => history.push('/catalog')}>Go back to the store</Button>
        </Container>
    );
}