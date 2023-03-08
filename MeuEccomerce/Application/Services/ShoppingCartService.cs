using MeuEccomerce.Domain.AggregatesModel.ShoppingCartAggregate;

namespace MeuEccomerce.API.Application.Services;

public class ShoppingCartService
{
    public ShoppingCartService(Guid id, List<ShoppingCartItem> shoppingCartItems = null)
    {
        Id = id;
        ShoppingCartItems = shoppingCartItems;
    }

    public Guid Id { get; set; }
    public List<ShoppingCartItem> ShoppingCartItems { get; set; }
    public static ShoppingCartService Get(IServiceProvider serviceProvider)
    {
        ISession session = serviceProvider.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

        var shoppingCartId = session.GetString("Id") ?? Guid.NewGuid().ToString();

        session.SetString("Id", shoppingCartId);
        var shoppingCart = new ShoppingCartService(Guid.Parse(shoppingCartId));

        return  shoppingCart;
    }

}
