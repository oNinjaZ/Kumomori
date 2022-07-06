using Kumomori.Api.Data;
using Kumomori.Api.Entities;
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

    [HttpGet]
    public async Task<ActionResult<Basket>> GetBasket()
    {
        var basket = await RetrieveBasket();

        if (basket is null)
            return NotFound();

        return basket;
    }

    [HttpPost]
    public async Task<ActionResult> AddItemToBasket(int bookId, int quantity)
    {
        var basket = await RetrieveBasket();
        if (basket is null)
            basket = CreateBasket();

        var book = await _context.Books.FindAsync(bookId);
        if (book is null)
            return NotFound();

        basket.AddItem(book, quantity);
        var result = await _context.SaveChangesAsync();

        if (result < 1)
            return BadRequest(new ProblemDetails { Title = "Problem saving item to basket" });

        return StatusCode(201);
    }

    [HttpDelete]
    public async Task<ActionResult> RemoveBasketItem(int bookId, int quantity)
    {
        // get basket
        // remove item or reduce quantity
        // save basket
        return await Task.FromResult(Ok());
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