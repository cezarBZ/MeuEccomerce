using MediatR;

namespace MeuEccomerce.API.Application.Commands.Category;

public class CreateCategoryCommand : IRequest<bool>
{
    public CreateCategoryCommand(string name, string description, string imageUrl)
    {
        Name = name;
        Description = description;
        ImageUrl = imageUrl;
    }

    public string Name { get; private set; }
    public string Description { get; private set; }
    public string ImageUrl { get; private set; }
}
