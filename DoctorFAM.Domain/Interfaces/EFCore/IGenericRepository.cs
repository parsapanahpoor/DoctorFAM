using System.Linq.Expressions;

namespace DoctorFAM.Domain.Interfaces.EFCore;

public interface IGenericRepository<TKey, TEntity> where TEntity : class
{
    Task AddAsync(TEntity entity, CancellationToken cancellationToken);
    Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken);
    Task<TEntity?> GetByIdAsync(TKey id, CancellationToken cancellationToken);
    Task<TEntity?> GetEntity(Expression<Func<TEntity, bool>> expression);
    void Update(TEntity entity);
    Task<IQueryable<TEntity>?> GetAllQueryable(Expression<Func<TEntity, bool>> expression);
}
