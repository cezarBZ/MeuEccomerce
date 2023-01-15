using MeuEccomerce.Domain.AggregatesModel.CategoryAggregate;
using MeuEccomerce.Infrastructure.Data;

namespace MeuEccomerce.Infrastructure.Repositories;

public class CategoryRepository : Repository<Category, int>, ICategoryRepository
{
    public CategoryRepository(ApplicationDataContext context) : base(context)
    {
    }
}