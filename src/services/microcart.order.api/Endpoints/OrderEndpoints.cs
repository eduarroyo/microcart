using microcart.order.api.Database;
using microcart.order.api.Entities;

namespace microcart.order.api.Endpoints;

public class CreateOrderRequest
{

}

public static class OrderEndpoints
{
    public static void MapProductEntpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("orders", async (
            CreateOrderRequest request,
            MicrocartDbContext context,
            CancellationToken ct) =>
        {
            var order = new Order
            {
                Id = Guid.NewGuid(),
                OrderDate = DateTime.Now,
                ShippingDate = DateTime.Now,
                Status = Entities.Enums.OrderStatus.Pending,
                Items = new List<Product>(),
                TotalAmount = 0
            };

            context.Orders.Add(order);
            await context.SaveChangesAsync(ct);
            return Results.Created($"/orders/{order.Id}", order);
        });
    }
}
