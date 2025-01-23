using microcart.order.api.Entities;
using Microsoft.EntityFrameworkCore;

namespace microcart.order.api.Database;

public class MicrocartDbContext: DbContext
{
    public MicrocartDbContext(DbContextOptions<MicrocartDbContext> options): base(options)
    {
    }

    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
}
