using Kumomori.Api.Data;
using Kumomori.Api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kumomori.Api.Controller;

public class BasketController : BaseApiController
{
    private readonly StoreContext _context;
    public BasketController(StoreContext context)
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
            basket = CreateNewBasket();

        // get book
        // add item
        // save basket

        return await Task.FromResult(StatusCode(201));
    }

    [HttpDelete]
    public async Task<ActionResult> RemoveBasketItem(int bookId, int quantity)
    {
        // get basket
        // remove item or reduce quantity
        // save basket
        return Ok();
    }

    private async Task<Basket?> RetrieveBasket()
    {
        return await _context.Baskets
                    .Include(i => i.Items)
                    .ThenInclude(b => b.Book)
                    .FirstOrDefaultAsync(x => x.BuyerId == Request.Cookies["buyerId"]);
    }
}