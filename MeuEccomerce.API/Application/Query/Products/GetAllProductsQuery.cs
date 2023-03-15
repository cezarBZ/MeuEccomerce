using MediatR;
using MeuEccomerce.API.Application.Models.DTO_s;

namespace MeuEccomerce.API.Application.Query.Products;
public class GetAllProductsQuery : IRequest<IReadOnlyList<ProductDTO>> 
{ 

}
