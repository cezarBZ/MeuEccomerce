using MeuEccomerce.Domain.Core.Data;
using MeuEccomerce.Domain.Core.Models;
using MeuEccomerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MeuEccomerce.Infrastructure.Repositories;

public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : Entity<TKey>, IAggregateRoot
{ 
    protected readonly ApplicationDataContext _context;
    protected readonly DbSet<TEntity> _entity;
    public virtual IUnitOfWork UnitOfWork => (IUnitOfWork)_context;
    public Repository(ApplicationDataContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _entity = _context.Set<TEntity>();
    }

    public void Add(TEntity entity)
    {
        _entity.Add(entity);
    }

    public void Delete(TEntity entity)
    {
        _entity.Remove(entity);
    }

    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }

    public IQueryable<TEntity> GetAll()
    {
        return _entity;
    }

    public virtual TEntity GetById(TKey Id)
    {
        return _entity.Find(Id);
    }

    public void Update(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        _entity.Update(entity);
    }

}
