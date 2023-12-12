using Flunt.Validations;

namespace Store.Domain.Entities;

public class OrderItem : BaseEntity
{
    public OrderItem(Product product, int quantity)
    {
        AddNotifications(
            new Contract<OrderItem>()
                .Requires()
                .IsNotNull(product, "Product", "The product can't be null")
                .IsGreaterThan(quantity, 0, "Quantity", "The quantity must be greater than 0")
        );

        Product = product;
        Price = Product != null ? Product.Price : 0;
        Quantity = quantity;
    }

    public Product Product { get; private set; } = null!;
    public decimal Price { get; private set; }
    public int Quantity { get; private set; }

    public decimal Total()
    {
        return Price * Quantity;
    }
}
