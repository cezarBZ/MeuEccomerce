using System.Linq.Expressions;

namespace MeuEccomerce.Domain.Core.Data;

public interface IRepository<TEntity, TKey> : IDisposable where TEntity : class
{
    IQueryable<TEntity> GetAll();
    TEntity GetById(TKey id);
    void Add(TEntity obj);
    void Update(TEntity obj);
    void Delete(TEntity entity);
    IUnitOfWork UnitOfWork { get; }
}
