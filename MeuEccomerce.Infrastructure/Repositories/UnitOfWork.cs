using MeuEccomerce.Domain.AggregatesModel.CategoryAggregate;
using MeuEccomerce.Domain.AggregatesModel.ProductAggregate;
using MeuEccomerce.Domain.Core.Data;
using MeuEccomerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace MeuEccomerce.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDataContext _context;
  
    public UnitOfWork(ApplicationDataContext context)
    {
        _context = context;
    }
    public int SaveChanges()
    {
        return _context.SaveChanges();
    }
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
    {
        return _context.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
