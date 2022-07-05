using Kumomori.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kumomori.Api.Data;

public class StoreContext : DbContext
{
    public StoreContext(DbContextOptions<StoreContext> options)
        : base(options)
    {
    }

    public DbSet<Book> Books { get; set; } = default!;
    public DbSet<Basket> Baskets { get; set; } = default!;
}