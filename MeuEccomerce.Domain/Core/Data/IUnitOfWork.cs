using MeuEccomerce.Domain.AggregatesModel.CategoryAggregate;
using MeuEccomerce.Domain.AggregatesModel.ProductAggregate;

namespace MeuEccomerce.Domain.Core.Data;

public interface IUnitOfWork
{
    IProductRepository productRepository { get; }
    ICategoryRepository categoryRepository { get; }
    public Task SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
}