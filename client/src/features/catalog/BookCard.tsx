import { LoadingButton } from "@mui/lab";
import { Button, Card, CardActions, CardContent, CardHeader, CardMedia, Typography } from "@mui/material";
import { useState } from "react";
import { Link } from "react-router-dom";
import agent from "../../app/api/agent";
import { useStoreContext } from "../../app/context/StoreContext";
import { Book } from "../../app/models/book";


interface Props {
  book: Book;
}

export default function BookCard({ book }: Props) {
  const [loading, setLoading] = useState(false);
  const {setBasket} = useStoreContext();
  
  function handleAddItem(bookId: number) {
    setLoading(true);
    agent.Basket.addItem(book.id)
      .then(basket => setBasket(basket))
      .catch(error => console.log(error))
      .finally(() => setLoading(false));
  }

  const publishDate = new Date(book.publishDate).toLocaleDateString('en-us', { year: 'numeric', month: 'numeric', day: 'numeric' });

  return (
    <>
      <Card>
        <CardHeader
          title={book.author}
          subheader={publishDate}
          titleTypographyProps={{
            sx: { fontWeight: 'bold' }
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
          <LoadingButton
            loading={loading} 
            onClick={() => handleAddItem(book.id)} 
            size="small">ADD TO CART</LoadingButton>
          <Button component={Link} to={`/catalog/${book.id}`} size="small">VIEW</Button>
        </CardActions>
      </Card>
    </>
  )
}