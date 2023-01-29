using MeuEccomerce.Domain.Core.Data;
using MeuEccomerce.Domain.Core.Models;
using MeuEccomerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MeuEccomerce.Infrastructure.Repositories;

public class Repository<T, TKey> : IRepository<T, TKey> where T : Entity<TKey>, IAggregateRoot
{ 
    protected readonly ApplicationDataContext _context;
    protected readonly DbSet<T> _entity;
    public virtual IUnitOfWork UnitOfWork => _context;
    public Repository(ApplicationDataContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _entity = _context.Set<T>();
    }

    public void Add(T entity)
    {
       _entity.Add(entity);
    }

    public void Delete(T entity)
    {
       _entity.Remove(entity);
    }

    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }

    public IQueryable<T> GetAll()
    {
        return _entity;
    }

    public virtual T GetById(TKey Id)
    {
        return _entity.Find(Id);
    }

    public void Update(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
       _entity.Update(entity);
    }
    public async Task<int> SaveChangesAsync()
    {
        var item = await _context.SaveChangesAsync().ConfigureAwait(false);
        return item;
    }

}
