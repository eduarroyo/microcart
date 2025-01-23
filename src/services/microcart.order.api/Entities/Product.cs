namespace microcart.order.api.Entities;

public class Product
{
    public int Id { get; set; } // ID único del producto
    public string Name { get; set; } // Nombre del producto
    public string Description { get; set; } // Descripción del producto

    public decimal Price { get; set; } // Precio del producto
    public int Quantity { get; set; } // Cantidad de unidades del producto
}
