using Kumomori.Api.Dtos;
using Kumomori.Api.Entities;

namespace Kumomori.Api.Extensions;

public static class MappingExtensions
{
    public static BasketDto AsDto(this Basket basket)
    {
        return new BasketDto
        {
            Id = basket.Id,
            BuyerId = basket.BuyerId,
            Items = basket.Items.Select(i => new BasketItemDto
            {
                BookId = i.BookId,
                Quantity = i.Quantity,
                Author = i.Book.Author,
                Title = i.Book.Title,
                Description = i.Book.Description,
                PageCount = i.Book.PageCount,
                Price = i.Book.Price,
                CoverUrl = i.Book.CoverUrl,
                Type = i.Book.Type,
                PublishDate = i.Book.PublishDate
            }).ToList()
        };
    }
}