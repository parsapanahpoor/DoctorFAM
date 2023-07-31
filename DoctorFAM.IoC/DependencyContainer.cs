#region Usings

using AngleSharp.Css.Dom;
using BusinessPortal.Application.Services.Implementation;
using DoctorFAM.Application.Interfaces;
using DoctorFAM.Application.Services;
using DoctorFAM.Application.Services.Implementation;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Data.Dapper.Repository;
using DoctorFAM.Data.Repository;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.Interfaces.Dapper;
using DoctorFAM.Domain.Interfaces.EFCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace DoctorFAM.IoC;

public static class DependencyContainer
{
    public static void RegisterServices(IServiceCollection services)
    {
        #region Services

        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ISiteSettingService, SiteSettingService>();
        services.AddScoped<IViewRenderService, ViewRenderService>();
        services.AddScoped<IEmailSender, EmailSender>();
        services.AddScoped<IPermissionService, PermissionService>();
        services.AddScoped<IHomeVisitService, HomeVisitService>();
        services.AddScoped<IHomeNurseService, HomeNurseService>();
        services.AddScoped<IDeathCertificateService, DeathCertificateService>();
        services.AddScoped<ILocationService, LocationService>();
        services.AddScoped<IRequestService, RequestServicecs>();
        services.AddScoped<IPatientService, PatientService>();
        services.AddScoped<IWalletService, WalletService>();
        services.AddScoped<IHomePharmacyServicec, HomePharmacyService>();
        services.AddScoped<IDoctorsService, DoctorsService>();
        services.AddScoped<IHomeLaboratoryServices, HomeLaboratoryService>();
        services.AddScoped<IHomePatientTransportService, HomePatientTransportService>();
        services.AddScoped<IMarketCategoryService, MarketCategoryService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IPopulationCoveredService, PopulationCoveredService>();
        services.AddScoped<IDashboardsService, DashboardsService>();
        services.AddScoped<IOrganizationService, OrganizationService>();
        services.AddScoped<ISMSService, SMSService>();
        services.AddScoped<IWorkAddressService, WorkAddressService>();
        services.AddScoped<IReservationService, ReservationService>();
        services.AddScoped<IPharmacyService, PharmacyService>();
        services.AddScoped<INotificationService, NotificationService>();
        services.AddScoped<IBMIService, BMIService>();
        services.AddScoped<IFamilyDoctorService, FamilyDoctorService>();
        services.AddScoped<IOnlineVisitService, OnlineVisitService>();
        services.AddScoped<ITicketService, TicketService>();
        services.AddScoped<INurseService, NurseService>();
        services.AddScoped<IConsultantService, ConsultantService>();
        services.AddScoped<ILaboratoryService, LaboratoryService>();
        services.AddScoped<IHealthInformationService, HealthInformationService>();
        services.AddScoped<IResumeService, ResumeService>();
        services.AddScoped<ICustomerAdvertisementService, CustomerAdvertisementService>();
        services.AddScoped<INewsService, NewsService>();
        services.AddScoped<IBookService, BookService>();
        services.AddScoped<IFollowService, FollowService>();
        services.AddScoped<ISpecialityService, SpecialityService>();
        services.AddScoped<IMedicalExaminationService, MedicalExaminationService>();
        services.AddScoped <IDrugAlertService, DrugAlertService>();
        services.AddScoped <IPeriodicSelftEvaluationService, PeriodicSelftEvaluationService>();
        services.AddScoped <IPeriodicTestService, PeriodicTestService>();
        services.AddScoped <ISelfAssessmentService, SelfAssessmentService>();
        services.AddScoped <IASCVDService, ASCVDService>();
        services.AddScoped <IChatService, ChatService>();
        services.AddScoped <ISMBGNoteBookService, SMBGNoteBookService>();
        services.AddScoped <IDentistService, DentistService>();
        services.AddScoped <IInterestService, InterestService>();
        services.AddScoped <IUserVirtualFilesService, UserVirtualFilesService>();
        services.AddScoped <ITourismService, TourismService>();

        #endregion

        #region EF Core Repository

        services.AddScoped<ILocationRepository, LocationRepository>();
        services.AddScoped<IHomeVisitRepository, HomeVisitRepository>();
        services.AddScoped<IHomeNurseRepository, HomeNurseRepository>();
        services.AddScoped<IDeathCertificateRepository, DeathCertificateRepository>();
        services.AddScoped<IPatientRepository, PatientRepository>();
        services.AddScoped<IRequestRepository, RequestRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IWalletRepository, WalletRepository>();
        services.AddScoped<IHomePharmacyRepository, HomePharmacyRepository>();
        services.AddScoped<IDoctorsRepository, DoctorsRepostory>();
        services.AddScoped<IHomeLaboratoryRepository, HomeLaboratoryRepository>();
        services.AddScoped<IHomePatientTransportRepository, HomePatientTransportRepository>();
        services.AddScoped<IMarketCategoryRepository, MarketCategoryRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ISiteSettingRepository, SiteSettingRepository>();
        services.AddScoped<IPopulationCoveredRepository, PopulationCoveredRepository>();
        services.AddScoped<IDashboardsRepository, DashboardsRepository>();
        services.AddScoped<IOrganizationRepository, OrganizationRepository>();
        services.AddScoped<IWorkAddressRepository, WorkAddressRepository>();
        services.AddScoped<IReservationRepository, ReservationRepository>();
        services.AddScoped<IPharmacyRepository, PharmacyRepository>();
        services.AddScoped<INotificationRepository, NotificationRepository>();
        services.AddScoped<IBMIRepository, BMIRepository>();
        services.AddScoped<IFamilyDoctorRepository, FamilyDoctorRepository>();
        services.AddScoped<IOnlineVisitRepository, OnlineVisitRepository>();
        services.AddScoped<ITicketRepository, TicketRepository>();
        services.AddScoped<INurseRepository, NurseRepository>();
        services.AddScoped<IConsultantRepository, ConsultantRepository>();
        services.AddScoped<ILaboratoryRepository, LaboratoryRepository>();
        services.AddScoped<IHealthInformationRepository, HealthInformationRepository>();
        services.AddScoped<IResumeRepository, ResumeRepository>();
        services.AddScoped<ICustomerAdvertisementRepository, CustomerAdvertisementRepository>();
        services.AddScoped<IFollowRepository, FollowRepository>();
        services.AddScoped<ISpecialityRepository, SpecialityRepository>();
        services.AddScoped<IMedicalExaminationRepository, MedicalExaminationRepository>();
        services.AddScoped<IDrugAlertRepository, DrugAlertRepository>();
        services.AddScoped<IPeriodicSelftEvaluationRepository, PeriodicSelftEvaluationRepository>();
        services.AddScoped<IPeriodicTestRepository, PeriodicTestRepository>();
        services.AddScoped<ISelfAssessmentRepository, SelfAssessmentRepository>();
        services.AddScoped<IASCVDRepository, ASCVDRepository>();
        services.AddScoped<IChatRepository, ChatRepository>();
        services.AddScoped<ISMBGNoteBookRepository, SMBGNoteBookRepository>();
        services.AddScoped<IDentistRepoistory, DentistRepoistory>();
        services.AddScoped<IInterestRepository, InterestRepository>();
        services.AddScoped<IUserVirtualFilesRepository, UserVirtualFilesRepository>();
        services.AddScoped<ITourismRepository, TourismRepository>();

        #endregion

        #region Dapper Repository

        services.AddScoped<IBMIRepositoryDapper, BMIRepositoryDapper>();
        services.AddScoped<IUserRepositoryDapper, UserRepositoryDapper>();
        services.AddScoped<ISMBGNoteBookDapper, SMBGNoteBookDapper>();

        #endregion
    }
}
