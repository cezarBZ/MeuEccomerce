using AutoMapper;
using MeuEccomerce.API.Application.Models.DTO_s;
using MeuEccomerce.API.Application.Models.ViewModels;
using MeuEccomerce.Domain.AggregatesModel.CategoryAggregate;
using MeuEccomerce.Domain.AggregatesModel.ProductAggregate;
using MeuEccomerce.Domain.AggregatesModel.UserAggregate;

namespace MeuEccomerce.API.Application.Mappings;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Category, CategoryDTO>().ReverseMap();
        CreateMap<Product, ProductDTO>().ReverseMap();
        CreateMap<Product, ProductViewModel>().ReverseMap();
        CreateMap<UserAddress,  UserAddressDTO>().ReverseMap();
    }
}
