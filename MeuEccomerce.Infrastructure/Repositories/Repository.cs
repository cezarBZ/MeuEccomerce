﻿using MeuEccomerce.Domain.Core.Data;
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

    public IReadOnlyList<T> GetAll(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
    {
        var query = _context.Set<T>();
        if (orderBy != null)
            return  orderBy(query).AsNoTracking().ToList();
        return  query.AsNoTracking().ToList();
    }
    public async Task<IReadOnlyList<T>> GetAllAsync(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
    {
        var query = _context.Set<T>();
        if (orderBy != null)
            return await orderBy(query).AsNoTracking().ToListAsync();

        return await query.AsNoTracking().ToListAsync();
    }
    public IReadOnlyList<T> Get(Expression<Func<T, bool>> predicate)
    {
        return  _context.Set<T>().Where(predicate).ToList();  
    }

    public T GetById(TKey id)
    {
        return _context.Set<T>().Find(id);
    }
    public virtual async Task<T> GetByIdAsync(TKey id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
        _context.SaveChanges();
    }

    public void Update(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
        _context.SaveChanges();
    }
    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }
}
