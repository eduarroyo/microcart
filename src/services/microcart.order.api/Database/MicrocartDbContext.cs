using microcart.order.api.Entities;
using Microsoft.EntityFrameworkCore;

namespace microcart.order.api.Database;

public class MicrocartDbContext: DbContext
{
    public MicrocartDbContext(DbContextOptions<MicrocartDbContext> options): base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder
            .UseAsyncSeeding(async (context, _, cancellationToken) =>
            {
                List<Product> products =
                [
                    new() {
                        Name = "Product 1",
                        Description = "Product 1",
                        Price = 10.0m,
                        Stock = 100
                    },
                    new() {
                        Name = "Product 2",
                        Description = "Product 2",
                        Price = 12.0m,
                        Stock = 40
                    },
                    new() {
                        Name = "Product 3",
                        Description = "Product 3",
                        Price = 15.0m,
                        Stock = 73
                    },
                    new() {
                        Name = "Product 4",
                        Description = "Product 4",
                        Price = 14.9m,
                        Stock = 61
                    }
                ];
                await context.Set<Product>().AddRangeAsync(products);

                List<Order> orders = [new Order(), new Order()];
                orders[0].AddProduct(products[0], 2);
                orders[0].AddProduct(products[1], 3);
                orders[1].AddProduct(products[1], 5);
                orders[1].AddProduct(products[2], 7);

                await context.Set<Order>().AddRangeAsync(orders);
                await context.SaveChangesAsync();
            });

    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
}
