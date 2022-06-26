import { Button, Card, CardActions, CardContent, CardHeader, CardMedia, Typography } from "@mui/material";
import { Link } from "react-router-dom";
import { Book } from "../../app/models/book";

interface Props {
  book: Book;
}

export default function BookCard({ book }: Props) {

  let publishDate = new Date(book.publishDate).toLocaleDateString('en-us', {year: 'numeric', month: 'numeric', day: 'numeric'})

  return (
    <>
      <Card>
        <CardHeader
          title={book.author}
          subheader={publishDate}
          titleTypographyProps={{
            sx: {fontWeight: 'bold'}
          }}
        />
        <CardMedia
          sx={{ height: 140, backgroundSize: 'contain' }}
          component="img"
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
          <Button component={Link} to={`/catalog/${book.id}`} size="small">VIEW</Button>
        </CardActions>
      </Card>
    </>
  )
}