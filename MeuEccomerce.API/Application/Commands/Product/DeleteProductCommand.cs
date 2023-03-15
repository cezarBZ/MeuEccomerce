using MediatR;

namespace MeuEccomerce.API.Application.Commands.Product;

public class DeleteProductCommand : IRequest<bool>
{
    public DeleteProductCommand(Guid productId)
    {
        ProductId = productId;
    }
    public Guid ProductId { get; private set; }
}
