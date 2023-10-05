#region Usings

using DoctorFAM.Application;
using DoctorFAM.Data.DbContext;
using DoctorFAM.Data.Repository;
using DoctorFAM.Domain.Entities.UsersBankAccount;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.Interfaces.EFCore;

namespace DoctorFAM.Data.UnitOfWork;

#endregion

public sealed partial class UnitOfWork : IApplicationUnitOfWork
{
    #region Ctor

    private readonly DoctorFAMDbContext _context;

    public UnitOfWork(DoctorFAMDbContext context)
    {
        _context = context;
        UserBankAccountRepository = new GenericRepository<ulong, UsersBankAccountsInfos>(_context);
        LocationRepository = new LocationRepository(_context);
        HomeNurseRepository = new HomeNurseRepository(_context);
        OrganizationRepository = new OrganizationRepository(_context);
        DeathCertificateRepository = new DeathCertificateRepository(_context , OrganizationRepository);
        PatientRepository = new PatientRepository(_context);
        DoctorsRepository = new DoctorsRepostory(_context);
        HomeVisitRepository = new HomeVisitRepository(_context,OrganizationRepository, DoctorsRepository);
        RequestRepository = new RequestRepository(_context);
        UserRepository = new UserRepository(_context);
        WalletRepository = new WalletRepository(_context);
        HomePharmacyRepository = new HomePharmacyRepository(_context);
        HomeLaboratoryRepository = new HomeLaboratoryRepository(_context);
        HomePatientTransportRepository = new HomePatientTransportRepository(_context);
        MarketCategoryRepository = new MarketCategoryRepository(_context);
        ProductRepository = new ProductRepository(_context);
        SiteSettingRepository = new SiteSettingRepository(_context);
        PopulationCoveredRepository = new PopulationCoveredRepository(_context);
        DashboardsRepository = new DashboardsRepository(_context, OrganizationRepository);
        WorkAddressRepository = new WorkAddressRepository(_context);
        ReservationRepository = new ReservationRepository(_context,OrganizationRepository,DoctorsRepository,UserRepository);
        PharmacyRepository = new PharmacyRepository(_context, OrganizationRepository);
        NotificationRepository = new NotificationRepository(_context);
        BMIRepository = new BMIRepository(_context);
        FamilyDoctorRepository = new FamilyDoctorRepository(_context);
        OnlineVisitRepository = new OnlineVisitRepository(_context);
        TicketRepository = new TicketRepository(_context);
        NurseRepository = new NurseRepository(_context, OrganizationRepository);
        ConsultantRepository = new ConsultantRepository(_context);
        LaboratoryRepository = new LaboratoryRepository(_context);
        HealthInformationRepository = new HealthInformationRepository(_context, OrganizationRepository);
        ResumeRepository = new ResumeRepository(_context);
        CustomerAdvertisementRepository = new CustomerAdvertisementRepository(_context);
        FollowRepository = new FollowRepository(_context);
        SpecialityRepository = new SpecialityRepository(_context);
        MedicalExaminationRepository = new MedicalExaminationRepository(_context);
        DrugAlertRepository = new DrugAlertRepository(_context);
        PeriodicSelftEvaluationRepository = new PeriodicSelftEvaluationRepository(_context);
        PeriodicTestRepository = new PeriodicTestRepository(_context);
        SelfAssessmentRepository = new SelfAssessmentRepository(_context);
        ASCVDRepository = new ASCVDRepository(_context);
        ChatRepository = new ChatRepository(_context);
        SMBGNoteBookRepository = new SMBGNoteBookRepository(_context);
        DentistRepoistory = new DentistRepoistory(_context);
        InterestRepository = new InterestRepository(_context);
        UserVirtualFilesRepository = new UserVirtualFilesRepository(_context);
        TourismRepository = new TourismRepository(_context);
        TouristTokenRepository = new TouristTokenRepository(_context);
        TouristTokenRepository = new TouristTokenRepository(_context);
    }

    #endregion

    #region Save Change

    public async Task CommitAsync(CancellationToken cancellationToken = default)
    {
        if (_disposed)
        {
            throw new ObjectDisposedException(this.GetType().FullName);
        }

        await _context.SaveChangesAsync(cancellationToken);
    }

    #endregion

    #region Dispose

    private bool _disposed = false;

    public async ValueTask DisposeAsync()
    {
        await DisposeAsync(true);

        GC.SuppressFinalize(this);
    }

    private async ValueTask DisposeAsync(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                await _context.DisposeAsync();
            }
            _disposed = true;
        }
    }

    #endregion
}
