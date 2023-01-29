using MediatR;
using MeuEccomerce.Domain.AggregatesModel.ProductAggregate;

namespace MeuEccomerce.API.Application.Query.Products
{
    public record GetProductByIdQuery(Guid productId) : IRequest<Product>;

}
