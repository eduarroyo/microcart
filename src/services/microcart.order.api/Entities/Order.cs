using microcart.order.api.Entities.Enums;
using Microsoft.EntityFrameworkCore;

namespace microcart.order.api.Entities;

/// <summary>
/// Order entity, represents an order made by a user
/// </summary>
[PrimaryKey(nameof(Id))]
public class Order
{
    /// <summary>
    /// Unique ID of the order
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Date when the order was created
    /// </summary>
    public DateTime CreationDate { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Date when the order was made
    /// </summary>
    public DateTime? OrderDate { get; set; } = default;

    /// <summary>
    /// Status of the order (draft, pending, completed, cancelled)
    /// </summary>
    public OrderStatus Status { get; set; } = OrderStatus.Draft;

    /// <summary>
    /// Total amount of the order, calculated from total ammount and price of products
    /// </summary>
    public decimal TotalAmount { get; private set; } = 0;

    /// <summary>
    /// Products that the order contains
    /// </summary>
    public ICollection<OrderProduct> Products { get; set; } = new List<OrderProduct>();


    public void AddProduct(Product product, int ammount)
    {
        if (product == null)
        {
            throw new ArgumentNullException(nameof(product));
        }
        if (ammount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(ammount));
        }
        var orderProduct = Products.FirstOrDefault(p => p.ProductId == product.Id);
        if (orderProduct == null)
        {
            orderProduct = new OrderProduct()
            {
                ProductId = product.Id,
                Price = product.Price,
                Ammount = ammount
            };
            Products.Add(orderProduct);
        }
        else
        {
            orderProduct.Ammount += ammount;
        }
        UpdateTotalAmmount();
    }

    public void RemoveProduct(Guid productId, int ammount)
    {
        OrderProduct? toRemove = Products.SingleOrDefault(p => p.ProductId == productId);
        if(toRemove == null)
        {
            return;
        }

        if(toRemove.Ammount < ammount)
        {
            toRemove.Ammount -= ammount;
        }
        else
        {
            Products.Remove(toRemove);
        }
    }

    private void UpdateTotalAmmount()
    {
        if(Products == null)
        {
            TotalAmount = 0;
            return;
        }

        TotalAmount = Products.Sum(p => p.Price * p.Ammount);
    }
}
