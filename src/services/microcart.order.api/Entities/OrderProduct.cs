namespace microcart.order.api.Entities;

public class OrderProduct
{
    public Order Order { get; set; } // Pedido al que pertenece el producto
    
    public Product Product { get; set; } // Producto del pedido

    public decimal Price { get; set; } // Precio del producto en el pedido

    public int Ammount { get; set; } // Cantidad del producto en el pedido
}
