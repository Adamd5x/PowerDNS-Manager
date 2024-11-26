using System.Linq.Expressions;
using hiPower.Abstracts;
using hiPower.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace hiPower.Repository;

public class GenericRepository<TEntity>(ManagerDbContext dbContext) : IGenericRepository<TEntity> where TEntity : class
{

    private readonly DbSet<TEntity> dbSet = dbContext.Set<TEntity>();

    public async Task<TEntity> CreateAsync (TEntity entity)
    {
        var result = await dbSet.AddAsync (entity);
        return result.Entity;
    }

    public async Task DeleteAsync (string id)
    {
        var entry = await dbSet.FindAsync(id);
        if (entry is not null)
        {
            dbSet.Remove (entry);
        }
    }

    public async Task<IEnumerable<TEntity>> GetAll (Expression<Func<TEntity, bool>>? expression, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? includes, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy)
    {
        IQueryable<TEntity> query = dbSet;

        if (expression is not null)
        {
            query = query.Where(expression);
        }

        if(includes is not null)
        {
            query = includes (query);
        }

        if(orderBy is not null)
        {
            query = orderBy (query);
        }

        return await query.AsNoTracking()
                          .ToListAsync();
    }

    public async Task<TEntity?> GetAsync (Expression<Func<TEntity, bool>>? expression, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? includes)
    {
        IQueryable<TEntity> query = dbSet;

        if (expression is not null)
        {
            query = query.Where(expression);
        }

        if (includes is not null)
        {
            query = includes (query);
            query = query.AsSplitQuery ();
        }

        return await query.AsNoTracking ()
                          .FirstOrDefaultAsync ();
    }

    public TEntity Updatec (TEntity entity)
    {
        dbSet.Update (entity);
        return entity;
    }
}
