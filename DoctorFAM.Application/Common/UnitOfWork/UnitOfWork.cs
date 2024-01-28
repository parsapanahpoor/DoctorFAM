using DoctorFAM.Data.DbContext;

namespace DoctorFAM.Application.Common.UnitOfWork;

public partial class UnitOfWork : DoctorFAM.Application.Common.IUnitOfWork.IUnitOfWork
{
    #region Using

    private readonly DoctorFAMDbContext _context;

    public UnitOfWork(DoctorFAMDbContext context)
    {
        _context = context;
    }

    #endregion

    #region Save Changes

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }

    #endregion

    #region Dispose

    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }

    public async ValueTask DisposeAsync()
    {
        await _context.DisposeAsync();
        GC.SuppressFinalize(this);
    }

    #endregion
}
