using MediatR;
using MeuEccomerce.API.Application.Models.ViewModels;
using MeuEccomerce.Domain.AggregatesModel.ProductAggregate;

namespace MeuEccomerce.API.Application.Query.Products;
public class GetAllProductsQuery : IRequest<IReadOnlyList<ProductViewModel>> 
{ 

}
