using MediatR;
using MeuEccomerce.API.Application.Models.DTO_s;
using MeuEccomerce.API.Application.Models.ViewModels;

namespace MeuEccomerce.API.Application.Query.Categories;

public class GetAllCategoriesQuery : IRequest<IReadOnlyList<CategoryDTO>> { };
