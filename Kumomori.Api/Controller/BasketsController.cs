using Kumomori.Api.Data;
using Kumomori.Api.Dtos;
using Kumomori.Api.Entities;
using Kumomori.Api.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kumomori.Api.Controller;

public class BasketsController : BaseApiController
{
    private readonly StoreContext _context;
    public BasketsController(StoreContext context)
    {
        _context = context;
    }

    [HttpGet(Name = "GetBasket")]
    public async Task<ActionResult<BasketDto>> GetBasket()
    {
        var basket = await RetrieveBasket();

        if (basket is null)
            return NotFound();

        return basket.AsDto();
    }

    [HttpPost]
    public async Task<ActionResult<BasketDto>> AddItemToBasket(int bookId, int quantity)
    {
        var basket = await RetrieveBasket();
        if (basket is null)
            basket = CreateBasket();

        var book = await _context.Books.FindAsync(bookId);
        if (book is null)
            return NotFound();

        basket.AddItem(book, quantity);
        var result = await _context.SaveChangesAsync() > 0;

        if (!result)
            return BadRequest(new ProblemDetails { Title = "Problem saving item to basket" });

        return CreatedAtRoute("GetBasket", new { id = basket.Id }, basket.AsDto());
    }

    [HttpDelete]
    public async Task<ActionResult> RemoveBasketItem(int bookId, int quantity)
    {
        var basket = await RetrieveBasket();
        if (basket is null)
            return NotFound();

        basket.RemoveItem(bookId, quantity);

        var result = await _context.SaveChangesAsync() > 0;
        if (result)
            return Ok();
        return BadRequest(new ProblemDetails { Title = "Problem removing item from the basket" });
    }

    private Basket CreateBasket()
    {
        var buyerId = Guid.NewGuid().ToString();
        var cookieOptions = new CookieOptions
        {
            IsEssential = true,
            Expires = DateTime.Now.AddDays(30)
        };

        Response.Cookies.Append("buyerId", buyerId, cookieOptions);

        var basket = new Basket { BuyerId = buyerId };

        _context.Baskets.Add(basket);
        return basket;
    }

    private async Task<Basket?> RetrieveBasket()
    {
        return await _context.Baskets
                    .Include(i => i.Items)
                    .ThenInclude(b => b.Book)
                    .FirstOrDefaultAsync(x => x.BuyerId == Request.Cookies["buyerId"]);
    }
}