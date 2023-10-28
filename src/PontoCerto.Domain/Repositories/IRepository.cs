using System.Linq.Expressions;

namespace PontoCerto.Domain.Repositories;

public interface IRepository<T> : IDisposable where T : class
{
    void Add(T entity);

    void Remove(T entity);

    void Update(T entity);
    
    Task SaveAsync();

    Task<T?> FirstAsync(Expression<Func<T, bool>>? expression, Func<IQueryable<T>, Func<T, object>>? include);

    Task<int> CountAsync(Expression<Func<T, bool>> expression);

    Task<List<T>> GetDataAsync(
        Expression<Func<T, bool>>? expression,
        Func<IQueryable<T>, Func<T, object>>? include,
        int? skip = null,
        int? take = null);
}