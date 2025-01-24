using microcart.order.api.Database;
using microcart.order.api.Entities;
using microcart.order.api.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace microcart.order.api.Endpoints;

public static class ProductEndpoints
{
    public static void MapProductEntpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("products", async (
            CreateProductRequest request,
            MicrocartDbContext context,
            CancellationToken ct) =>
        {
            var product = new Product()
            {
                Description = request.Description,
                Name = request.Name,
                Price = request.Price,
                Stock = request.Stock,
            };
            context.Products.Add(product);
            await context.SaveChangesAsync(ct);
            return Results.Created($"/products/{product.Id}", product);
        });

        app.MapGet("products", async (
            MicrocartDbContext context,
            CancellationToken ct) =>
        {
            var orders = await context.Products.ToListAsync(ct);
            return Results.Ok(orders);
        });

        app.MapGet("products/{id}", async (
            MicrocartDbContext context,
            [FromRoute] Guid id,
            CancellationToken ct) =>
        {
            var product = await context.Products.FindAsync(id);
            if(product is null)
            {
                return Results.NotFound();
            }

            return Results.Ok(product);
        });
    }
}
