namespace Kumomori.Api.Entities;

public class Basket
{
    public int Id { get; set; }
    public string BuyerId { get; set; } = default!;
    public List<BasketItem> Items { get; set; } = new();


    public void AddItem(Book book, int quantity)
    {
        if (Items.All(item => book.Id != item.BookId))
        {
            Items.Add(new BasketItem
            {
                Book = book,
                Quantity = quantity
            });
        }

        var existingItem = Items.FirstOrDefault(item => book.Id == item.BookId);
        if (existingItem != null)
            existingItem.Quantity += quantity;
    }

    public void RemoveItem(int bookId, int quantity)
    {
        var item = Items.FirstOrDefault(item => item.BookId == bookId);
        if (item == null)
            return;

        item.Quantity -= quantity;

        if (item.Quantity < 1)
            Items.Remove(item);
    }
}