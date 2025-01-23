using microcart.order.api.Entities.Enums;

namespace microcart.order.api.Entities;

public class Order
{
    public int Id { get; set; } // ID único del pedido

    public DateTime OrderDate { get; set; } // Fecha en que se realiza el pedido

    public DateTime? ShippingDate { get; set; } // Fecha estimada de envío (opcional)

    public OrderStatus Status { get; set; } // Estado del pedido (pendiente, completado, cancelado)

    public decimal TotalAmount { get; set; } // Total del pedido (puede ser calculado con base en los productos y cantidades)

    public ICollection<Product> Items { get; set; } // Lista de productos que contiene el pedido
}
