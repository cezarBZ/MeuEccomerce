using MeuEccomerce.Domain.AggregatesModel.ProductAggregate;
using MeuEccomerce.Infrastructure.Data;

namespace MeuEccomerce.Infrastructure.Repositories;

public class ProductRepository : Repository<Product, Guid>, IProductRepository
{
    
    public ProductRepository(ApplicationDataContext context) : base(context)
    {
    }
}

