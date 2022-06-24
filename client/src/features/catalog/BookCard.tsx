import { Button, Card, CardActions, CardContent, CardHeader, CardMedia, Typography } from "@mui/material";
import { Book } from "../../app/models/book";

interface Props {
  book: Book;
}

export default function BookCard({ book }: Props) {
  return (
    <>
      <Card>
        <CardHeader
          title={book.author}
          subheader={book.publishDate.toString()}
        />
        <CardMedia
          component="img"
          height="140"
          image={book.coverUrl}
        />
        <CardContent>
          <Typography gutterBottom variant="h6" component="div" maxHeight={40} textOverflow='ellipsis' overflow='hidden'>
            {book.title}
          </Typography>
          <Typography variant="body2" color="text.secondary" maxHeight={70} textOverflow='ellipsis' overflow='hidden'>
            {book.description}
          </Typography>
        </CardContent>
        <CardActions>
          <Button size="small">ADD TO CART</Button>
          <Button size="small">VIEW</Button>
        </CardActions>
      </Card>
    </>
  )
}