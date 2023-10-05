using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.Entities.UsersBankAccount;

namespace DoctorFAM.Data.UnitOfWork
{
    public sealed partial class UnitOfWork
    {
        public ILocationRepository LocationRepository { get; private set; }
        public IHomeVisitRepository HomeVisitRepository { get; private set; }
        public IHomeNurseRepository HomeNurseRepository { get; private set; }
        public IDeathCertificateRepository DeathCertificateRepository { get; private set; }
        public IPatientRepository PatientRepository { get; private set; }
        public IRequestRepository RequestRepository { get; private set; }
        public IUserRepository UserRepository { get; private set; }
        public IWalletRepository WalletRepository { get; private set; }
        public IHomePharmacyRepository HomePharmacyRepository { get; private set; }
        public IDoctorsRepository DoctorsRepository { get; private set; }
        public IHomeLaboratoryRepository HomeLaboratoryRepository { get; private set; }
        public IHomePatientTransportRepository HomePatientTransportRepository { get; private set; }
        public IMarketCategoryRepository MarketCategoryRepository { get; private set; }
        public IProductRepository ProductRepository { get; private set; }
        public ISiteSettingRepository SiteSettingRepository { get; private set; }
        public IPopulationCoveredRepository PopulationCoveredRepository { get; private set; }
        public IDashboardsRepository DashboardsRepository { get; private set; }
        public IOrganizationRepository OrganizationRepository { get; private set; }
        public IWorkAddressRepository WorkAddressRepository { get; private set; }
        public IReservationRepository ReservationRepository { get; private set; }
        public IPharmacyRepository PharmacyRepository { get; private set; }
        public INotificationRepository NotificationRepository { get; private set; }
        public IBMIRepository BMIRepository { get; private set; }
        public IFamilyDoctorRepository FamilyDoctorRepository { get; private set; }
        public IOnlineVisitRepository OnlineVisitRepository { get; private set; }
        public ITicketRepository TicketRepository { get; private set; }
        public INurseRepository NurseRepository { get; private set; }
        public IConsultantRepository ConsultantRepository { get; private set; }
        public ILaboratoryRepository LaboratoryRepository { get; private set; }
        public IHealthInformationRepository HealthInformationRepository { get; private set; }
        public IResumeRepository ResumeRepository { get; private set; }
        public ICustomerAdvertisementRepository CustomerAdvertisementRepository { get; private set; }
        public IFollowRepository FollowRepository { get; private set; }
        public ISpecialityRepository SpecialityRepository { get; private set; }
        public IMedicalExaminationRepository MedicalExaminationRepository { get; private set; }
        public IDrugAlertRepository DrugAlertRepository { get; private set; }
        public IPeriodicSelftEvaluationRepository PeriodicSelftEvaluationRepository { get; private set; }
        public IPeriodicTestRepository PeriodicTestRepository { get; private set; }
        public ISelfAssessmentRepository SelfAssessmentRepository { get; private set; }
        public IASCVDRepository ASCVDRepository { get; private set; }
        public IChatRepository ChatRepository { get; private set; }
        public ISMBGNoteBookRepository SMBGNoteBookRepository { get; private set; }
        public IDentistRepoistory DentistRepoistory { get; private set; }
        public IInterestRepository InterestRepository { get; private set; }
        public IUserVirtualFilesRepository UserVirtualFilesRepository { get; private set; }
        public ITourismRepository TourismRepository { get; private set; }
        public ITouristTokenRepository TouristTokenRepository { get; private set; }
        public IGenericRepository<ulong, UsersBankAccountsInfos> UserBankAccountRepository { get; private set; }

    }
}
