using Kumomori.Api.Data;
using Kumomori.Api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kumomori.Api.Controller;

public class BooksController : BaseApiController
{
    private readonly StoreContext _context;
    public BooksController(StoreContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Book>>> GetBooks()
    {
        var books = await _context.Books.ToListAsync();
        return Ok(books);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Book>> GetBook(int id)
    {
        if (await _context.Books.FindAsync(id) is not Book book)
            return NotFound();

        return Ok(book);
    }
}