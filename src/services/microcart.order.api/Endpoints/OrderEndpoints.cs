using microcart.order.api.Database;
using microcart.order.api.Entities;
using microcart.order.api.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace microcart.order.api.Endpoints;

public static class OrderEndpoints
{
    public static void MapOrderEntpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("orders", async (
            CreateOrderRequest request,
            MicrocartDbContext context,
            CancellationToken ct) =>
        {
            var order = new Order();
            context.Orders.Add(order);
            await context.SaveChangesAsync(ct);
            return Results.Created($"/orders/{order.Id}", order);
        });

        app.MapGet("orders", async (
            MicrocartDbContext context,
            CancellationToken ct) =>
        {
            var orders = await context.Orders.Include(o => o.Products).ToListAsync(ct);
            return Results.Ok(orders);
        });

        app.MapGet("orders/{id}", async (
            MicrocartDbContext context,
            [FromRoute] Guid id,
            CancellationToken ct) =>
        {
            var order = await context.Orders.FindAsync(id);
            if (order is null)
            {
                return Results.NotFound();
            }
            await context.Entry(order).Collection(o => o.Products).LoadAsync();

            return Results.Ok(order);
        });
    }
}
