using MeuEccomerce.Domain.AggregatesModel.CategoryAggregate;
using MeuEccomerce.Domain.AggregatesModel.ProductAggregate;
using MeuEccomerce.Domain.Core.Data;
using MeuEccomerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MeuEccomerce.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDataContext _appDbContext;
    public UnitOfWork(ApplicationDataContext appDbContext)
    {
        _appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
        productRepository = new ProductRepository(_appDbContext);
        categoryRepository = new CategoryRepository(_appDbContext);
    }

    public IProductRepository productRepository { get; }
    public ICategoryRepository categoryRepository { get; }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
    {
        await _appDbContext.SaveChangesAsync(cancellationToken);
    }
}
