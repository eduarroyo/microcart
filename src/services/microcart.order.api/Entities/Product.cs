using Microsoft.EntityFrameworkCore;

namespace microcart.order.api.Entities;

[PrimaryKey(nameof(Id))]
public class Product
{
    public Guid Id { get; set; } = Guid.NewGuid(); // ID único del producto
    public string Name { get; set; } // Nombre del producto
    public string Description { get; set; } // Descripción del producto
    public decimal Price { get; set; } // Precio del producto
    public int Stock { get; set; } // Cantidad de unidades del producto
}
