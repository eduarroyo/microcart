using Microsoft.EntityFrameworkCore;

namespace microcart.order.api.Entities;

[PrimaryKey(nameof(OrderId), nameof(ProductId))]
public class OrderProduct
{
    /// <summary>
    /// ID of the order to which the product belongs
    /// </summary>
    public Guid OrderId { get; set; }

    /// <summary>
    /// ID of the product in the order
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// Precio del producto en el pedido
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Ammount of the product in the order
    /// </summary>
    public int Ammount { get; set; }

    /// <summary>
    /// Product that the order contains
    /// </summary>
    public Product Product { get; set; } = null!;
}
