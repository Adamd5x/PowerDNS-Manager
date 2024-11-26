using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

namespace hiPower.Abstracts;

public interface IGenericRepository<TEntity> where TEntity : class
{
    Task<IEnumerable<TEntity>> GetAll (Expression<Func<TEntity, bool>>? expression, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? includes, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy);
    Task<TEntity?> GetAsync (Expression<Func<TEntity, bool>>? expression, Func<IQueryable<TEntity>,IIncludableQueryable<TEntity, object>>? includes);
    Task<TEntity> CreateAsync(TEntity entity);
    TEntity Update(TEntity entity);
    Task DeleteAsync(string id);
}
