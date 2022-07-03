using System.ComponentModel.DataAnnotations.Schema;

namespace Kumomori.Api.Entities
{
    [Table("BasketItems")]
    public class BasketItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        // navigation properties
        public int BookId { get; set; }
        public Book? Book { get; set; }

        public int BasketId { get; set; }
        public Basket Basket { get; set; } = default!;
    }
}