using System.Linq.Expressions;

namespace MeuEccomerce.Domain.Core.Data;

public interface IRepository<T, TKey> : IDisposable where T : class
{
    IQueryable<T> GetAll();
    T GetById(TKey id);
    void Add(T obj);
    void Update(T obj);
    void Delete(T entity);
    IUnitOfWork UnitOfWork { get; }
}
