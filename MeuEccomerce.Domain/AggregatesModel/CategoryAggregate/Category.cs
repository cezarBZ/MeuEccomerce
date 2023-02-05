using MeuEccomerce.Domain.Core.Models;

namespace MeuEccomerce.Domain.AggregatesModel.CategoryAggregate;

public class Category : Entity<int>, IAggregateRoot
{
    public Category()
    {

    }
    public Category(string name, string description, string imageUrl)
    {
        Name = name;
        Description = description;
        ImageUrl = imageUrl;
        IsEnabled = true;
    }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public string ImageUrl { get; private set; }
    public bool IsEnabled { get; private set; }

    public void Disable()
    {
        this.IsEnabled = false;
    }

    public void Enable()
    {
        this.IsEnabled = true;
    }
}
