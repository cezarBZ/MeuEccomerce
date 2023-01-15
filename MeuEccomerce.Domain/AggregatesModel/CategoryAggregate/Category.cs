using MeuEccomerce.Domain.AggregatesModel.ProductAggregate;
using MeuEccomerce.Domain.Core.Models;

namespace MeuEccomerce.Domain.AggregatesModel.CategoryAggregate;

public class Category : Entity<int>, IAggregateRoot
{
    public Category(string name, string description, string imageUrl)
    {
        Name = name;
        Description = description;
        ImageUrl = imageUrl;
    }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
}
