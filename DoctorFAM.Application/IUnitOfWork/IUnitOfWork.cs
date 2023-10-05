using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.UsersBankAccount;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.Interfaces.EFCore;
using Microsoft.EntityFrameworkCore;

namespace DoctorFAM.Application
{
    public interface IUnitOfWork :  IAsyncDisposable
    {
        Task CommitAsync(CancellationToken cancellationToken = default);
    }

    public interface IApplicationUnitOfWork : IUnitOfWork
    {
        public ILocationRepository LocationRepository { get; }
        public IHomeVisitRepository HomeVisitRepository { get; }
        public IHomeNurseRepository HomeNurseRepository { get; }
        public IDeathCertificateRepository DeathCertificateRepository { get; }
        public IPatientRepository PatientRepository { get; }
        public IRequestRepository RequestRepository { get; }
        public IUserRepository UserRepository { get; }
        public IWalletRepository WalletRepository { get; }
        public IHomePharmacyRepository HomePharmacyRepository { get; }
        public IDoctorsRepository DoctorsRepository { get; }
        public IHomeLaboratoryRepository HomeLaboratoryRepository { get; }
        public IHomePatientTransportRepository HomePatientTransportRepository { get; }
        public IMarketCategoryRepository MarketCategoryRepository { get; }
        public IProductRepository ProductRepository { get; }
        public ISiteSettingRepository SiteSettingRepository { get; }
        public IPopulationCoveredRepository PopulationCoveredRepository{ get; }
        public IDashboardsRepository DashboardsRepository { get; }
        public IOrganizationRepository OrganizationRepository { get; }
        public IWorkAddressRepository WorkAddressRepository { get; }
        public IReservationRepository ReservationRepository { get; }
        public IPharmacyRepository PharmacyRepository { get; }
        public INotificationRepository NotificationRepository { get; }
        public IBMIRepository BMIRepository { get; }
        public IFamilyDoctorRepository FamilyDoctorRepository { get; }
        public IOnlineVisitRepository OnlineVisitRepository { get; }
        public ITicketRepository TicketRepository { get; }
        public INurseRepository NurseRepository { get; }
        public IConsultantRepository ConsultantRepository { get; }
        public ILaboratoryRepository LaboratoryRepository { get; }
        public IHealthInformationRepository HealthInformationRepository { get; }
        public IResumeRepository ResumeRepository { get; }
        public ICustomerAdvertisementRepository CustomerAdvertisementRepository { get; }
        public IFollowRepository FollowRepository { get; }
        public ISpecialityRepository SpecialityRepository { get; }
        public IMedicalExaminationRepository MedicalExaminationRepository { get; }
        public IDrugAlertRepository DrugAlertRepository { get; }
        public IPeriodicSelftEvaluationRepository PeriodicSelftEvaluationRepository { get; }
        public IPeriodicTestRepository PeriodicTestRepository { get; }
        public ISelfAssessmentRepository SelfAssessmentRepository { get; }
        public IASCVDRepository ASCVDRepository { get; }
        public IChatRepository ChatRepository { get; }
        public ISMBGNoteBookRepository SMBGNoteBookRepository { get; }
        public IDentistRepoistory DentistRepoistory { get; }
        public IInterestRepository InterestRepository { get; }
        public IUserVirtualFilesRepository UserVirtualFilesRepository { get; }
        public ITourismRepository TourismRepository { get; }
        public ITouristTokenRepository TouristTokenRepository { get; }
        public IGenericRepository<ulong, UsersBankAccountsInfos> UserBankAccountRepository { get; }
    }
}
