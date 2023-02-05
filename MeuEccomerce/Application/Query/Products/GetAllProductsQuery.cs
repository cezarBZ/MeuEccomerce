using MediatR;
using MeuEccomerce.API.Application.Models.ViewModels;

namespace MeuEccomerce.API.Application.Query.Products;
public class GetAllProductsQuery : IRequest<IReadOnlyList<ProductViewModel>> 
{ 

}
