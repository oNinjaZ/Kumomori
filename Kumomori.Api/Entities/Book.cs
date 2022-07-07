namespace Kumomori.Api.Entities;

public class Book
{
    public int Id { get; set; }
    public string Author { get; set; } = default!;
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public int PageCount { get; set; }
    public long Price { get; set; }
    public string CoverUrl { get; set; } = default!;
    public string Type { get; set; } = default!;
    public int QuantityInStock { get; set; }
    public DateTime PublishDate { get; set; }
}