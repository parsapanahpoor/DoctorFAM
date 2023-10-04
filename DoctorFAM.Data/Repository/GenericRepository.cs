using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Interfaces.EFCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace DoctorFAM.Data.Repository;

public class GenericRepository<TKey, TEntity> : IGenericRepository<TKey, TEntity> where TEntity : class
{
    #region Ctor
    private DbSet<TEntity> DbSet { get; set; }

    public GenericRepository(DoctorFAMDbContext dbContext)
    {
        DbSet = dbContext.Set<TEntity>();
    }

    #endregion

    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken)
    {
        await DbSet.AddAsync(entity, cancellationToken);
    }

    public async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken)
    {
        await DbSet.AddRangeAsync(entities, cancellationToken);
    }

    public async Task<TEntity?> GetByIdAsync(TKey id, CancellationToken cancellationToken)
    {
        return await DbSet.FindAsync(id, cancellationToken);
    }

    public async Task<TEntity?> GetEntity(Expression<Func<TEntity, bool>> expression)
    {
        return await DbSet.FirstOrDefaultAsync(expression);
    }

    public async Task<IQueryable<TEntity>?> GetAllQueryable(Expression<Func<TEntity, bool>> expression)
    {
        return  DbSet.Where(expression).AsQueryable();
    }

    public void Update(TEntity entity)
    {
        DbSet.Update(entity);
    }
}
