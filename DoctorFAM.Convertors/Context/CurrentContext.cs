using Academy.Domain.Entities.SiteSetting;
using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Advertisement;
using DoctorFAM.Domain.Entities.ASCVD;
using DoctorFAM.Domain.Entities.BMI;
using DoctorFAM.Domain.Entities.Consultant;
using DoctorFAM.Domain.Entities.Contact;
using DoctorFAM.Domain.Entities.DoctorReservation;
using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.DurgAlert;
using DoctorFAM.Domain.Entities.FamilyDoctor.ParsaSystem;
using DoctorFAM.Domain.Entities.FamilyDoctor.VIPSystem;
using DoctorFAM.Domain.Entities.FamilyDoctor;
using DoctorFAM.Domain.Entities.FollowAndUnFollow;
using DoctorFAM.Domain.Entities.HealthInformation;
using DoctorFAM.Domain.Entities.Insurance;
using DoctorFAM.Domain.Entities.Interest;
using DoctorFAM.Domain.Entities.Laboratory;
using DoctorFAM.Domain.Entities.Languages;
using DoctorFAM.Domain.Entities.MarketCategory;
using DoctorFAM.Domain.Entities.News;
using DoctorFAM.Domain.Entities.Notification;
using DoctorFAM.Domain.Entities.Nurse;
using DoctorFAM.Domain.Entities.OnlineVisit;
using DoctorFAM.Domain.Entities.Organization;
using DoctorFAM.Domain.Entities.PeriodicSelfEvaluatuion;
using DoctorFAM.Domain.Entities.PeriodicTest;
using DoctorFAM.Domain.Entities.Pharmacy;
using DoctorFAM.Domain.Entities.PriodicExamination;
using DoctorFAM.Domain.Entities.Product;
using DoctorFAM.Domain.Entities.Requests;
using DoctorFAM.Domain.Entities.Resume;
using DoctorFAM.Domain.Entities.SelfAssessment;
using DoctorFAM.Domain.Entities.SiteSetting;
using DoctorFAM.Domain.Entities.Speciality;
using DoctorFAM.Domain.Entities.States;
using DoctorFAM.Domain.Entities.Wallet;
using DoctorFAM.Domain.Entities.WorkAddress;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using DoctorFAM.Domain.Entities.PopulationCovered;
using DoctorFAM.Domain.Entities.Patient;
using DoctorFAM.Domain.Entities.CooperationRequest;

namespace DoctorFAM.Convertors.Context
{
    public class CurrentContext : DbContext
    {
        #region Constructor

        public CurrentContext()
        {

        }

        public CurrentContext(DbContextOptions<CurrentContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-CM9A86V\\MSSQL2019;Initial Catalog=DoctorFAMDb;Integrated Security=True");
            }
        }

        #endregion

        #region DbSets

        #region Account 

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<RolePermission> RolePermissions { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<CooperationRequest> CooperationRequests { get; set; }

        #endregion

        #region Wallet

        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<WalletData> WalletData { get; set; }

        #endregion

        #region Email & Site Setting

        public DbSet<EmailSetting> EmailSettings { get; set; }

        public DbSet<SiteSetting> SiteSettings { get; set; }

        public DbSet<TariffForHealthHouseServices> TariffForHealthHouseServices { get; set; }

        #endregion

        #region Patient

        public DbSet<Patient> Patients { get; set; }

        #endregion

        #region Request

        public DbSet<RequestSelectedHealthHouseTariff> RequestSelectedHealthHouseTariff { get; set; }

        public DbSet<Request> Requests { get; set; }

        public DbSet<PaitientRequestDetail> PaitientRequestDetails { get; set; }

        public DbSet<PatientRequestDateTimeDetail> PatientRequestDateTimeDetails { get; set; }

        public DbSet<ReservationDateCancelation> ReservationDateCancelations { get; set; }

        public DbSet<ReservationDateTimeCancelation> ReservationDateTimeCancelations { get; set; }

        public DbSet<RequestTransferingPriceFromOperator> TransferingPriceFromOperators { get; set; }

        public DbSet<HomeVisitRequestDetail> HomeVisitRequestDetails { get; set; }

        public DbSet<LogForDeclineHomeVisitRequestFromUser> LogForDeclineHomeVisitRequestFromUser { get; set; }

        #endregion

        #region Language

        public DbSet<Language> languages { get; set; }

        #endregion

        #region Location

        public DbSet<Location> Locations { get; set; }

        public DbSet<LocationInfo> LocationInfoes { get; set; }

        #endregion

        #region Category

        public DbSet<Category> Category { get; set; }

        public DbSet<CategoryInfo> CategoryInfos { get; set; }

        #endregion

        #region Pharmacy

        public DbSet<HomePharmacyRequestDetail> HomePharmacyRequestDetails { get; set; }

        #endregion

        #region Doctors

        public DbSet<DoctorsInfo> DoctorsInfos { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<DoctorsSelectedInterests> DoctorsSelectedInterests { get; set; }

        public DbSet<DoctorsSkils> DoctorSkill { get; set; }

        #endregion

        #region Pharmacy

        public DbSet<Pharmacy> Pharmacies { get; set; }

        public DbSet<PharmacyInfo> PharmacyInfos { get; set; }

        public DbSet<PharmacySelectedInterests> PharmacySelectedInterests { get; set; }

        public DbSet<HomePharmacyRequestDetailPrice> HomePharmacyRequestDetailPrices { get; set; }

        #endregion

        #region Population Covered

        public DbSet<PopulationCovered> PopulationCovered { get; set; }

        #endregion

        #region Laboratory

        public DbSet<HomeLaboratoryRequestDetail> HomeLaboratoryRequestDetails { get; set; }

        #endregion

        #region Products

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductFeature> ProductFeatures { get; set; }

        public DbSet<ProductGallery> ProductGalleries { get; set; }

        public DbSet<ProductSelectedCategory> ProductSelectedCategories { get; set; }

        public DbSet<ProductsTags> ProductsTags { get; set; }

        #endregion

        #region Interests

        public DbSet<DoctorsInterest> Interests { get; set; }

        public DbSet<DoctorsInterestInfo> InterestInfos { get; set; }

        public DbSet<PharmacyInterests> PharmacyInterests { get; set; }

        public DbSet<PharmacyInterestInfo> PharmacyInterestInfos { get; set; }

        public DbSet<DiabetConsultantsResume> DiabetConsultantsResumes { get; set; }

        public DbSet<BloodPressureConsultantResume> BloodPressureConsultantResumes { get; set; }

        #endregion

        #region Organization

        public DbSet<Organization> Organizations { get; set; }

        public DbSet<OrganizationMember> OrganizationMembers { get; set; }

        #endregion

        #region Work Address

        public DbSet<WorkAddress> WorkAddresses { get; set; }

        #endregion

        #region Doctor Reservation

        public DbSet<DoctorReservationDate> DoctorReservationDates { get; set; }

        public DbSet<DoctorReservationDateTime> DoctorReservationDateTimes { get; set; }

        public DbSet<LogForCloseReservation> LogForCloseReservations { get; set; }

        public DbSet<DoctorPersonalBooking> DoctorPersonalBooking { get; set; }

        #endregion

        #region Notification 

        public DbSet<SupporterNotification> SupporterNotification { get; set; }

        #endregion

        #region BMI

        public DbSet<BMI> BMI { get; set; }

        public DbSet<GFR> GFR { get; set; }

        #endregion

        #region Online Visit Request Detail

        public DbSet<OnlineVisitRequestDetail> OnlineVisitRequestDetails { get; set; }

        #endregion

        #region Ticket 

        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<TicketMessage> TicketMessages { get; set; }

        #endregion

        #region Family Doctor 

        public DbSet<UserSelectedFamilyDoctor> UserSelectedFamilyDoctor { get; set; }

        public DbSet<UserInsertedFromParsaSystem> UserInsertedFromParsaSystems { get; set; }

        public DbSet<LogForSendSMSToUsersIncomeFromParsa> LogForSendSMSToUsersIncomeFromParsa { get; set; }

        public DbSet<VIPUserInsertedFromDoctorSystem> VIPUserInsertedFromDoctorSystem { get; set; }

        public DbSet<LogForSendSMSToVIPUsersIncomeFromDoctorSystem> LogForSendSMSToVIPUsersIncomeFromDoctorSystem { get; set; }

        public DbSet<LabelOfVIPDoctorInsertedPatient> LabelOfVIPDoctorInsertedPatient { get; set; }

        public DbSet<DoctorsLabelsForVIPInsertedDoctor> DoctorsLabelsForVIPInsertedDoctor { get; set; }

        public DbSet<RequestForUploadExcelFileFromDoctorsToSite> RequestForUploadExcelFileFromDoctorsToSite { get; set; }

        #endregion

        #region Nurse 

        public DbSet<Nurse> Nurses { get; set; }

        public DbSet<NurseInfo> NurseInfo { get; set; }

        #endregion

        #region Consultant

        public DbSet<Consultant> consultant { get; set; }

        public DbSet<ConsultantInfo> ConsultantInfos { get; set; }

        public DbSet<UserSelectedConsultant> UserSelectedConsultants { get; set; }

        #endregion

        #region Laboratory 

        public DbSet<Laboratory> Laboratory { get; set; }

        public DbSet<LaboratoryInfo> LaboratoryInfos { get; set; }

        #endregion

        #region Health Information 

        public DbSet<TVFAMCategory> TVFAMCategories { get; set; }

        public DbSet<TVFAMCategoryInfo> TVFAMCategoryInfos { get; set; }

        public DbSet<RadioFAMCategory> RadioFAMCategories { get; set; }

        public DbSet<RadioFAMCategoryInfo> RadioFAMCategoryInfos { get; set; }

        public DbSet<HealthInformationTag> HealthInformationTags { get; set; }

        public DbSet<HealthInformation> HealthInformation { get; set; }

        public DbSet<RadioFAMSelectedCategory> RadioFAMSelectedCategories { get; set; }

        public DbSet<TVFAMSelectedCategory> TVFAMSelectedCategories { get; set; }

        #endregion

        #region Resume

        public DbSet<Resume> Resumes { get; set; }

        public DbSet<ResumeAboutMe> ResumeAboutMe { get; set; }

        public DbSet<EducationResume> EducationResume { get; set; }

        public DbSet<WorkHistoryResume> WorkHistoryResume { get; set; }

        public DbSet<Honors> Honors { get; set; }

        public DbSet<ServiceResume> ServiceResume { get; set; }

        public DbSet<WorkingAddressResume> WorkingAddressResume { get; set; }

        public DbSet<CertificateResume> CertificateResume { get; set; }

        public DbSet<GalleryResume> GalleryResume { get; set; }

        #endregion

        #region Customer Advertisement

        public DbSet<CustomerAdvertisement> CustomerAdvertisement { get; set; }

        #endregion

        #region News 

        public DbSet<News> News { get; set; }

        public DbSet<NewsTag> NewsTags { get; set; }

        public DbSet<NewsCategory> NewsCategories { get; set; }

        public DbSet<NewsComment> NewsComments { get; set; }

        public DbSet<NewsSelectedCategory> NewsSelectedCategory { get; set; }

        #endregion

        #region Speciality

        public DbSet<Speciality> Specialities { get; set; }

        public DbSet<SpecialtiyInfo> SpecialtiyInfos { get; set; }

        public DbSet<DoctorSelectedSpeciality> DoctorSelectedSpeciality { get; set; }

        #endregion

        #region Follow

        public DbSet<Follow> Follow { get; set; }

        #endregion

        #region Priodic Examinations

        public DbSet<MedicalExamination> MedicalExaminations { get; set; }

        public DbSet<PriodicPatientsExamination> PriodicPatientsExamination { get; set; }

        #endregion

        #region Drug Alert

        public DbSet<DrugAlert> DrugAlerts { get; set; }

        public DbSet<DrugAlertDetail> DrugAlertDetails { get; set; }

        #endregion

        #region Periodic Self Evaluation 

        public DbSet<DiabetRiskFactorQuestions> DiabetRiskFactorQuestions { get; set; }

        #endregion

        #region ASCVD

        public DbSet<ASCVD> ASCVD { get; set; }

        #endregion

        #region Periodic Test 

        public DbSet<PeriodicTest> PeriodicTests { get; set; }

        public DbSet<UserPeriodicTest> UserPeriodicTests { get; set; }

        #endregion

        #region Slef Assessments

        public DbSet<DiabetSelfAssessment> DiabetSelfAssessments { get; set; }

        public DbSet<BloodPressureSelfAssessment> BloodPressureSelfAssessments { get; set; }

        #endregion

        #region Insurance

        public DbSet<Insurance> Insurance { get; set; }

        #endregion

        #endregion

        #region On Model Creating

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);
        }

        #endregion
    }
}
