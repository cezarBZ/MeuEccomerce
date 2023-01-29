using MeuEccomerce.Domain.AggregatesModel.CategoryAggregate;
using MeuEccomerce.Domain.AggregatesModel.ProductAggregate;

namespace MeuEccomerce.Domain.Core.Data;

public interface IUnitOfWork : IDisposable
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
}