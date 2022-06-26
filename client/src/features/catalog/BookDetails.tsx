import { Typography } from "@mui/material";
import { useParams } from "react-router-dom";

export default function BookDetails() {

    const {id} = useParams<{id: string}>();

    return (
        <Typography variant='h2'>
            Book Details Page
        </Typography>
    )
}