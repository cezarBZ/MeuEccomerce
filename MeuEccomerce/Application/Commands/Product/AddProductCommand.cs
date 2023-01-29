using MediatR;

namespace MeuEccomerce.API.Application.Commands.Product;

public class AddProductCommand : IRequest<bool>
{
    public AddProductCommand(string name, string description, decimal price, string imageUrl, int inventory, int categoryId)
    {
        Name = name;
        Description = description;
        Price = price;
        ImageUrl = imageUrl;
        Inventory = inventory;
        CategoryId = categoryId;
    }

    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public string ImageUrl { get; private set; }
    public int Inventory { get; private set; }
    public int CategoryId { get; private set; }
}
