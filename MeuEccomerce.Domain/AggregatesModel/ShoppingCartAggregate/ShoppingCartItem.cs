using MeuEccomerce.Domain.Core.Models;

namespace MeuEccomerce.Domain.AggregatesModel.ShoppingCartAggregate;

public class ShoppingCartItem : Entity<int>, IAggregateRoot
{
    public ShoppingCartItem(Guid productId, int quantity, Guid shoppingCartId, decimal price)
    {
        ProductId = productId;
        Quantity = quantity;
        ShoppingCartId = shoppingCartId;
        Price = price;
    }

    public Guid ProductId { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public Guid ShoppingCartId { get; set; }


}
