using MediatR;
using MeuEccomerce.API.Application.Models.DTO_s;

namespace MeuEccomerce.API.Application.Query.Products
{
    public class GetProductByIdQuery : IRequest<ProductDTO>
    {
        public GetProductByIdQuery(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }

    }
}
