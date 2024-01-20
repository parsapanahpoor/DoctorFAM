namespace DoctorFAM.Application.Common.IUnitOfWork;

public interface IUnitOfWork : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Save all entities in to database.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
