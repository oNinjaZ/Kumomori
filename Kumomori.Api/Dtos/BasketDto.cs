namespace Kumomori.Api.Dtos;

public class BasketDto
{
    public int Id { get; set; }
    public string BuyerId { get; set; } = default!;
    public List<BasketItemDto> Items { get; set; } = new();
}