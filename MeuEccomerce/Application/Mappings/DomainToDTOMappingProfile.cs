using AutoMapper;
using MeuEccomerce.Domain.AggregatesModel.CategoryAggregate;
using MeuEccomerce.Domain.AggregatesModel.ProductAggregate;

namespace MeuEccomerce.API.Application.Mappings;

public class DomainToDTOMappingProfile : Profile
{
    public DomainToDTOMappingProfile()
    {
        //CreateMap<Category, CategoriaDTO>().ReverseMap();
        //CreateMap<Product, ProdutoDTO>().ReverseMap();
    }
}
