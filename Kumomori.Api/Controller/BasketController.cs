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
        var basket = await _context.Baskets
            .Include(i => i.Items)
            .ThenInclude(b => b.Book)
            .FirstOrDefaultAsync(x => x.BuyerId == Request.Cookies["buyerId"]);

        if (basket is null)
            return NotFound();
        
        return basket;
    }
}