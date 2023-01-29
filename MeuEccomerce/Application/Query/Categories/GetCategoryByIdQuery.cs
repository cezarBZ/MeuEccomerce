using MediatR;
using MeuEccomerce.Domain.AggregatesModel.CategoryAggregate;

namespace MeuEccomerce.API.Application.Query.Categories;

public record GetCategoryByIdQuery(int categoryId) : IRequest<Category>;


