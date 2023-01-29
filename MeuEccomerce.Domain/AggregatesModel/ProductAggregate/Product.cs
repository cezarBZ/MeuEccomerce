using MeuEccomerce.Domain.Core.Models;

namespace MeuEccomerce.Domain.AggregatesModel.ProductAggregate;

public class Product : Entity<Guid>, IAggregateRoot
{
    public Product(string name, string description, decimal price, string imageUrl, int inventory, DateTime registerDate, int categoryId, string categoryName)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        Price = price;
        ImageUrl = imageUrl;
        Inventory = inventory;
        RegisterDate = registerDate;
        CategoryName = categoryName;
        CategoryId = categoryId;
    }

    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public string ImageUrl { get; private set; }
    public int Inventory { get; private set; }
    public DateTime RegisterDate { get; private set; }
    public string CategoryName { get; private set; }
    public int CategoryId { get; private set; }
}
