using Academy.Domain.Entities.SiteSetting;
using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.A1C;
using DoctorFAM.Domain.Entities.A1C_SMBG_NoteBook_;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Advertisement;
using DoctorFAM.Domain.Entities.ASCVD;
using DoctorFAM.Domain.Entities.BMI;
using DoctorFAM.Domain.Entities.Chat;
using DoctorFAM.Domain.Entities.Consultant;
using DoctorFAM.Domain.Entities.Contact;
using DoctorFAM.Domain.Entities.CooperationRequest;
using DoctorFAM.Domain.Entities.DoctorReservation;
using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.Drugs;
using DoctorFAM.Domain.Entities.DurgAlert;
using DoctorFAM.Domain.Entities.FamilyDoctor;
using DoctorFAM.Domain.Entities.FamilyDoctor.ParsaSystem;
using DoctorFAM.Domain.Entities.FamilyDoctor.VIPSystem;
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
using DoctorFAM.Domain.Entities.Patient;
using DoctorFAM.Domain.Entities.PeriodicSelfEvaluatuion;
using DoctorFAM.Domain.Entities.PeriodicTest;
using DoctorFAM.Domain.Entities.Pharmacy;
using DoctorFAM.Domain.Entities.PopulationCovered;
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
using DoctorFAM.Domain.Enums.PeriodicTestType;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Globalization;

namespace DoctorFAM.Data.DbContext
{
    public class DoctorFAMDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        #region Ctor

        public DoctorFAMDbContext(DbContextOptions<DoctorFAMDbContext> options) : base(options)
        {
        }

        #endregion

        #region DbSets

        #region A1C & SMBG

        public DbSet<LogForUsageInsulin> LogForUsageInsulin { get; set; }

        public DbSet<LogForUsersA1C> logForUsersA1Cs { get; set; }

        #endregion

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

        public DbSet<RequestTransferingPriceFromOperator> TransferingPriceFromOperators{ get; set; }

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

        #region Chat 

        public DbSet<Chat> Chats { get; set; }

        public DbSet<ChatGroup> ChatGroups { get; set; }

        public DbSet<ChatGroupMember> ChatGroupMembers { get; set; }

        #endregion

        #region Drugs

        public DbSet<Insulin> Insulins { get; set; }

        #endregion

        #endregion

        #region On Model Creating

        public string culture = CultureInfo.CurrentCulture.Name;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            //modelBuilder.Entity<PopulationCovered>()
            // .HasOne(c => c.Insurance)
            // .WithMany(c => c.PopulationCovered)
            // .HasForeignKey(p=> p.InsuranceId)
            // .OnDelete(DeleteBehavior.NoAction);

            #region Seed Data

            #region Language Seed Data

            modelBuilder.Entity<Language>().HasData(new Language
            {
                SystemName = "en-US",
                Title = "English",
                IsActive = true
            });

            modelBuilder.Entity<Language>().HasData(new Language
            {
                SystemName = "fa-IR",
                Title = "فارسی",
                IsActive = true
            });

            modelBuilder.Entity<Language>().HasData(new Language
            {
                SystemName = "tr-TR",
                Title = "Turkish",
                IsActive = true
            });

            modelBuilder.Entity<Language>().HasData(new Language
            {
                SystemName = "ar-SA",
                Title = "Arabic",
                IsActive = true
            });

            #endregion

            #endregion

            #region Role Seed Data

            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = 1,
                Title = "Admin",
                RoleUniqueName = "Admin",
                CreateDate = DateTime.Now,
                IsDelete = false,
                ParentId = null
            });

            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = 2,
                Title = "Doctor",
                RoleUniqueName = "Doctor",
                CreateDate = DateTime.Now,
                IsDelete = false,
                ParentId = null
            });

            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = 3,
                Title = "Support",
                RoleUniqueName = "Support",
                CreateDate = DateTime.Now,
                IsDelete = false,
                ParentId = null
            });

            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = 4,
                Title = "Seller",
                RoleUniqueName = "Seller",
                CreateDate = DateTime.Now,
                IsDelete = false,
                ParentId = null
            });

            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = 5,
                Title = "DoctorOfficeEmployee",
                RoleUniqueName = "DoctorOfficeEmployee",
                CreateDate = DateTime.Now,
                IsDelete = false,
                ParentId = null
            });

            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = 6,
                Title = "Pharmacy",
                RoleUniqueName = "Pharmacy",
                CreateDate = DateTime.Now,
                IsDelete = false,
                ParentId = null
            });

            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = 7,
                Title = "HomeVisit",
                RoleUniqueName = "HomeVisit",
                CreateDate = DateTime.Now,
                IsDelete = false,
                ParentId = 3
            });

            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = 8,
                Title = "HomeNurse",
                RoleUniqueName = "HomeNurse",
                CreateDate = DateTime.Now,
                IsDelete = false,
                ParentId = 3
            });

            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = 9,
                Title = "HomePharmacy",
                RoleUniqueName = "HomePharmacy",
                CreateDate = DateTime.Now,
                IsDelete = false,
                ParentId = 3
            });

            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = 10,
                Title = "HomeLabratory",
                RoleUniqueName = "HomeLabratory",
                CreateDate = DateTime.Now,
                IsDelete = false,
                ParentId = 3
            });

            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = 11,
                Title = "HomePatientTransport",
                RoleUniqueName = "HomePatientTransport",
                CreateDate = DateTime.Now,
                IsDelete = false,
                ParentId = 3
            });

            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = 12,
                Title = "DeathCertificate",
                RoleUniqueName = "DeathCertificate",
                CreateDate = DateTime.Now,
                IsDelete = false,
                ParentId = 3
            });

            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = 13,
                Title = "OnlineVisit",
                RoleUniqueName = "OnlineVisit",
                CreateDate = DateTime.Now,
                IsDelete = false,
                ParentId = 3
            });

            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = 14,
                Title = "Nurse",
                RoleUniqueName = "Nurse",
                CreateDate = DateTime.Now,
                IsDelete = false,
                ParentId = null
            });

            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = 15,
                Title = "Consultant",
                RoleUniqueName = "Consultant",
                CreateDate = DateTime.Now,
                IsDelete = false,
                ParentId = null
            });

            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = 16,
                Title = "Labratory",
                RoleUniqueName = "Labratory",
                CreateDate = DateTime.Now,
                IsDelete = false,
                ParentId = null
            });

            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = 17,
                Title = "LaboratoryOfficeEmployee",
                RoleUniqueName = "LaboratoryOfficeEmployee",
                CreateDate = DateTime.Now,
                IsDelete = false,
                ParentId = null
            });

            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = 18,
                Title = "نمونه گیر",
                RoleUniqueName = "LaboratorySampler",
                CreateDate = DateTime.Now,
                IsDelete = false,
                ParentId = 17
            });

            #endregion

            #region query filter

            modelBuilder.Entity<LocationInfo>().HasQueryFilter(e => e.LanguageId == culture);

            modelBuilder.Entity<CategoryInfo>().HasQueryFilter(e => e.LanguageId == culture);

            modelBuilder.Entity<DoctorsInterestInfo>().HasQueryFilter(e => e.LanguageId == culture);

            modelBuilder.Entity<PharmacyInterestInfo>().HasQueryFilter(e => e.LanguageId == culture);

            modelBuilder.Entity<TVFAMCategoryInfo>().HasQueryFilter(e => e.LanguageId == culture);

            modelBuilder.Entity<RadioFAMCategoryInfo>().HasQueryFilter(e => e.LanguageId == culture);

            modelBuilder.Entity<SpecialtiyInfo>().HasQueryFilter(e => e.LanguageId == culture);

            #endregion

            #region Email Setting Seed Data

            var date = new DateTime(2022, 03, 01);

            modelBuilder.Entity<EmailSetting>().HasData(new EmailSetting
            {
                Id = 1,
                Password = "Reza@83040697",
                IsDelete = false,
                CreateDate = date,
                IsDefaultEmail = true,
                DisplayName = "DoctorFAm",
                From = "maghsoudlou.reza@gmail.com",
                Smtp = "smtp.gmail.com",
                EnableSsL = true,
                Port = 587,
                UserName = "DoctorFAm"
            });

            #endregion

            #region Doctor Interests Seed Data

            #region Interests

            modelBuilder.Entity<DoctorsInterest>().HasData(new DoctorsInterest
            {
                Id = 1,
                CreateDate = DateTime.Now,
                IsDelete = false
            });

            modelBuilder.Entity<DoctorsInterest>().HasData(new DoctorsInterest
            {
                Id = 2,
                CreateDate = DateTime.Now,
                IsDelete = false
            });

            modelBuilder.Entity<DoctorsInterest>().HasData(new DoctorsInterest
            {
                Id = 3,
                CreateDate = DateTime.Now,
                IsDelete = false
            });

            modelBuilder.Entity<DoctorsInterest>().HasData(new DoctorsInterest
            {
                Id = 4,
                CreateDate = DateTime.Now,
                IsDelete = false
            });

            modelBuilder.Entity<DoctorsInterest>().HasData(new DoctorsInterest
            {
                Id = 5,
                CreateDate = DateTime.Now,
                IsDelete = false
            });

            modelBuilder.Entity<DoctorsInterest>().HasData(new DoctorsInterest
            {
                Id = 6,
                CreateDate = DateTime.Now,
                IsDelete = false
            });

            #endregion

            #region Interest Info

            modelBuilder.Entity<DoctorsInterestInfo>().HasData(new DoctorsInterestInfo
            {
                Id = 1,
                InterestId = 1,
                IsDelete = false,
                CreateDate = DateTime.Now,
                LanguageId = "fa-IR",
                Title = "ویزیت آنلاین"
            });

            modelBuilder.Entity<DoctorsInterestInfo>().HasData(new DoctorsInterestInfo
            {
                Id = 2,
                InterestId = 1,
                IsDelete = false,
                CreateDate = DateTime.Now,
                LanguageId = "en-US",
                Title = "Online Visit"
            });

            modelBuilder.Entity<DoctorsInterestInfo>().HasData(new DoctorsInterestInfo
            {
                Id = 3,
                InterestId = 1,
                IsDelete = false,
                CreateDate = DateTime.Now,
                LanguageId = "tr-TR",
                Title = "çevrimiçi ziyaret"
            });

            modelBuilder.Entity<DoctorsInterestInfo>().HasData(new DoctorsInterestInfo
            {
                Id = 4,
                InterestId = 1,
                IsDelete = false,
                CreateDate = DateTime.Now,
                LanguageId = "ar-SA",
                Title = "زيارة عبر الإنترنت"
            });

            modelBuilder.Entity<DoctorsInterestInfo>().HasData(new DoctorsInterestInfo
            {
                Id = 5,
                InterestId = 2,
                IsDelete = false,
                CreateDate = DateTime.Now,
                LanguageId = "ar-SA",
                Title = "زيارة منزلية"
            });

            modelBuilder.Entity<DoctorsInterestInfo>().HasData(new DoctorsInterestInfo
            {
                Id = 6,
                InterestId = 2,
                IsDelete = false,
                CreateDate = DateTime.Now,
                LanguageId = "tr-TR",
                Title = "Ev ziyareti"
            });

            modelBuilder.Entity<DoctorsInterestInfo>().HasData(new DoctorsInterestInfo
            {
                Id = 7,
                InterestId = 2,
                IsDelete = false,
                CreateDate = DateTime.Now,
                LanguageId = "fa-IR",
                Title = "ویزیت در منزل"
            });

            modelBuilder.Entity<DoctorsInterestInfo>().HasData(new DoctorsInterestInfo
            {
                Id = 8,
                InterestId = 2,
                IsDelete = false,
                CreateDate = DateTime.Now,
                LanguageId = "en-US",
                Title = "Home Visit"
            });

            modelBuilder.Entity<DoctorsInterestInfo>().HasData(new DoctorsInterestInfo
            {
                Id = 9,
                InterestId = 3,
                IsDelete = false,
                CreateDate = DateTime.Now,
                LanguageId = "en-US",
                Title = "Family Doctor"
            });

            modelBuilder.Entity<DoctorsInterestInfo>().HasData(new DoctorsInterestInfo
            {
                Id = 10,
                InterestId = 3,
                IsDelete = false,
                CreateDate = DateTime.Now,
                LanguageId = "tr-TR",
                Title = "aile hekimliği"
            });

            modelBuilder.Entity<DoctorsInterestInfo>().HasData(new DoctorsInterestInfo
            {
                Id = 11,
                InterestId = 3,
                IsDelete = false,
                CreateDate = DateTime.Now,
                LanguageId = "ar-SA",
                Title = "أطباء الأسرة"
            });

            modelBuilder.Entity<DoctorsInterestInfo>().HasData(new DoctorsInterestInfo
            {
                Id = 12,
                InterestId = 3,
                IsDelete = false,
                CreateDate = DateTime.Now,
                LanguageId = "fa-IR",
                Title = "پزشک خانواده"
            });

            modelBuilder.Entity<DoctorsInterestInfo>().HasData(new DoctorsInterestInfo
            {
                Id = 13,
                InterestId = 4,
                IsDelete = false,
                CreateDate = DateTime.Now,
                LanguageId = "fa-IR",
                Title = "صدور گواهی فوت"
            });

            modelBuilder.Entity<DoctorsInterestInfo>().HasData(new DoctorsInterestInfo
            {
                Id = 14,
                InterestId = 4,
                IsDelete = false,
                CreateDate = DateTime.Now,
                LanguageId = "en-US",
                Title = "Issuance of death certificate"
            });

            modelBuilder.Entity<DoctorsInterestInfo>().HasData(new DoctorsInterestInfo
            {
                Id = 15,
                InterestId = 4,
                IsDelete = false,
                CreateDate = DateTime.Now,
                LanguageId = "tr-TR",
                Title = "Ölüm belgesi verilmesi"
            });

            modelBuilder.Entity<DoctorsInterestInfo>().HasData(new DoctorsInterestInfo
            {
                Id = 16,
                InterestId = 4,
                IsDelete = false,
                CreateDate = DateTime.Now,
                LanguageId = "ar-SA",
                Title = "اصدار شهادة وفاة"
            });

            modelBuilder.Entity<DoctorsInterestInfo>().HasData(new DoctorsInterestInfo
            {
                Id = 17,
                InterestId = 5,
                IsDelete = false,
                CreateDate = DateTime.Now,
                LanguageId = "fa-IR",
                Title = "مشاور دیابت"
            });

            modelBuilder.Entity<DoctorsInterestInfo>().HasData(new DoctorsInterestInfo
            {
                Id = 18,
                InterestId = 5,
                IsDelete = false,
                CreateDate = DateTime.Now,
                LanguageId = "en-US",
                Title = "Diabetes consultant"
            });

            modelBuilder.Entity<DoctorsInterestInfo>().HasData(new DoctorsInterestInfo
            {
                Id = 19,
                InterestId = 5,
                IsDelete = false,
                CreateDate = DateTime.Now,
                LanguageId = "tr-TR",
                Title = "diyabet danışmanı"
            });

            modelBuilder.Entity<DoctorsInterestInfo>().HasData(new DoctorsInterestInfo
            {
                Id = 20,
                InterestId = 5,
                IsDelete = false,
                CreateDate = DateTime.Now,
                LanguageId = "ar-SA",
                Title = "استشاري مرض السكر"
            });

            modelBuilder.Entity<DoctorsInterestInfo>().HasData(new DoctorsInterestInfo
            {
                Id = 21,
                InterestId = 6,
                IsDelete = false,
                CreateDate = DateTime.Now,
                LanguageId = "fa-IR",
                Title = "مشاور فشارخون"
            });

            modelBuilder.Entity<DoctorsInterestInfo>().HasData(new DoctorsInterestInfo
            {
                Id = 22,
                InterestId = 6,
                IsDelete = false,
                CreateDate = DateTime.Now,
                LanguageId = "en-US",
                Title = "Blood pressure consultant"
            });

            modelBuilder.Entity<DoctorsInterestInfo>().HasData(new DoctorsInterestInfo
            {
                Id = 23,
                InterestId = 6,
                IsDelete = false,
                CreateDate = DateTime.Now,
                LanguageId = "tr-TR",
                Title = "tansiyon danışmanı"
            });

            modelBuilder.Entity<DoctorsInterestInfo>().HasData(new DoctorsInterestInfo
            {
                Id = 24,
                InterestId = 6,
                IsDelete = false,
                CreateDate = DateTime.Now,
                LanguageId = "ar-SA",
                Title = "استشاري ضغط الدم"
            });

            #endregion

            #endregion

            #region Insurance Seed Data 

            modelBuilder.Entity<Insurance>().HasData(new Insurance
            {
                Id = 1,
                CreateDate = DateTime.Now,
                IsDelete = false,
                Title = "بیمه سلامت"
            });

            modelBuilder.Entity<Insurance>().HasData(new Insurance
            {
                Id = 2,
                CreateDate = DateTime.Now,
                IsDelete = false,
                Title = "بیمه ی تامین اجتماعی"
            });

            modelBuilder.Entity<Insurance>().HasData(new Insurance
            {
                Id = 3,
                CreateDate = DateTime.Now,
                IsDelete = false,
                Title = "مشاغل آزاد"
            });

            modelBuilder.Entity<Insurance>().HasData(new Insurance
            {
                Id = 4,
                CreateDate = DateTime.Now,
                IsDelete = false,
                Title = "بیمه ی ایرانیان"
            });

            modelBuilder.Entity<Insurance>().HasData(new Insurance
            {
                Id = 5,
                CreateDate = DateTime.Now,
                IsDelete = false,
                Title = "آزاد"
            });

            #endregion

            #region Doctor Speciality Seed Data 

            #region Speciality

            modelBuilder.Entity<Speciality>().HasData(new Speciality
            {
                Id = 1,
                CreateDate = DateTime.Now,
                IsDelete = false,
                UniqueName = "متخصص پزشک خانواده",
                UniqueId = 1,
                IsSuperSpecialty = false,
                IsSpecialty = false,
                IsTitle = true
            });

            modelBuilder.Entity<Speciality>().HasData(new Speciality
            {
                Id = 2,
                CreateDate = DateTime.Now,
                IsDelete = false,
                UniqueName = "داخلی",
                UniqueId = 2,
                IsSuperSpecialty = false,
                IsSpecialty = false,
                IsTitle = true
            });

            modelBuilder.Entity<Speciality>().HasData(new Speciality
            {
                Id = 3,
                CreateDate = DateTime.Now,
                IsDelete = false,
                UniqueName = "متخصص داخلی",
                UniqueId = 3,
                ParentId = 2,
                IsSuperSpecialty = false,
                IsSpecialty = true,
                IsTitle = false
            });

            modelBuilder.Entity<Speciality>().HasData(new Speciality
            {
                Id = 4,
                CreateDate = DateTime.Now,
                IsDelete = false,
                UniqueName = "فوق تخصص غدد",
                UniqueId = 4,
                ParentId = 2,
                IsSuperSpecialty = true,
                IsSpecialty = false,
                IsTitle = false
            });

            modelBuilder.Entity<Speciality>().HasData(new Speciality
            {
                Id = 5,
                CreateDate = DateTime.Now,
                IsDelete = false,
                UniqueName = "قلب و عروق",
                UniqueId = 4,
                IsSuperSpecialty = false,
                IsSpecialty = false,
                IsTitle = true
            });

            modelBuilder.Entity<Speciality>().HasData(new Speciality
            {
                Id = 6,
                CreateDate = DateTime.Now,
                IsDelete = false,
                UniqueName = " متخصص قلب و عروق",
                UniqueId = 5,
                ParentId = 5,
                IsSuperSpecialty = false,
                IsSpecialty = true,
                IsTitle = false
            });

            modelBuilder.Entity<Speciality>().HasData(new Speciality
            {
                Id = 7,
                CreateDate = DateTime.Now,
                IsDelete = false,
                UniqueName = "فوق تخصص قلب وعروق",
                UniqueId = 6,
                ParentId = 5,
                IsSuperSpecialty= true,
                IsSpecialty = false,
                IsTitle = false
            });

            modelBuilder.Entity<Speciality>().HasData(new Speciality
            {
                Id = 8,
                CreateDate = DateTime.Now,
                IsDelete = false,
                UniqueName = "متخصص پزشک خانواده",
                UniqueId = 8,
                IsSuperSpecialty = false,
                IsSpecialty = true,
                IsTitle = false,
                ParentId = 1
            });

            #endregion

            #region Speciality Info

            modelBuilder.Entity<SpecialtiyInfo>().HasData(new SpecialtiyInfo
            {
                Id = 1,
                SpecialityId = 1,
                IsDelete = false,
                CreateDate = DateTime.Now,
                LanguageId = "fa-IR",
                Title = "متخصص پزشک خانواده",
            });

            modelBuilder.Entity<SpecialtiyInfo>().HasData(new SpecialtiyInfo
            {
                Id = 2,
                SpecialityId = 1,
                IsDelete = false,
                CreateDate = DateTime.Now,
                LanguageId = "en-US",
                Title = "Family doctor specialist"
            });

            modelBuilder.Entity<SpecialtiyInfo>().HasData(new SpecialtiyInfo
            {
                Id = 3,
                SpecialityId = 1,
                IsDelete = false,
                CreateDate = DateTime.Now,
                LanguageId = "tr-TR",
                Title = "Aile hekimi uzmanı"
            });

            modelBuilder.Entity<SpecialtiyInfo>().HasData(new SpecialtiyInfo
            {
                Id = 4,
                SpecialityId = 1,
                IsDelete = false,
                CreateDate = DateTime.Now,
                LanguageId = "ar-SA",
                Title = "أخصائي طب الأسرة"
            });

            modelBuilder.Entity<SpecialtiyInfo>().HasData(new SpecialtiyInfo
            {
                Id = 5,
                SpecialityId = 2,
                IsDelete = false,
                CreateDate = DateTime.Now,
                LanguageId = "fa-IR",
                Title = "داخلی",
            });

            modelBuilder.Entity<SpecialtiyInfo>().HasData(new SpecialtiyInfo
            {
                Id = 6,
                SpecialityId = 2,
                IsDelete = false,
                CreateDate = DateTime.Now,
                LanguageId = "en-US",
                Title = "Internal"
            });

            modelBuilder.Entity<SpecialtiyInfo>().HasData(new SpecialtiyInfo
            {
                Id = 7,
                SpecialityId = 2,
                IsDelete = false,
                CreateDate = DateTime.Now,
                LanguageId = "tr-TR",
                Title = "Dahili"
            });

            modelBuilder.Entity<SpecialtiyInfo>().HasData(new SpecialtiyInfo
            {
                Id = 8,
                SpecialityId = 2,
                IsDelete = false,
                CreateDate = DateTime.Now,
                LanguageId = "ar-SA",
                Title = "داخلي"
            });

            modelBuilder.Entity<SpecialtiyInfo>().HasData(new SpecialtiyInfo
            {
                Id = 9,
                SpecialityId = 3,
                IsDelete = false,
                CreateDate = DateTime.Now,
                LanguageId = "fa-IR",
                Title = "متخصص داخلی",
            });

            modelBuilder.Entity<SpecialtiyInfo>().HasData(new SpecialtiyInfo
            {
                Id = 10,
                SpecialityId = 3,
                IsDelete = false,
                CreateDate = DateTime.Now,
                LanguageId = "en-US",
                Title = "Internist"
            });

            modelBuilder.Entity<SpecialtiyInfo>().HasData(new SpecialtiyInfo
            {
                Id = 11,
                SpecialityId = 3,
                IsDelete = false,
                CreateDate = DateTime.Now,
                LanguageId = "tr-TR",
                Title = "dahiliyeci"
            });

            modelBuilder.Entity<SpecialtiyInfo>().HasData(new SpecialtiyInfo
            {
                Id = 12,
                SpecialityId = 3,
                IsDelete = false,
                CreateDate = DateTime.Now,
                LanguageId = "ar-SA",
                Title = "طبيب باطني"
            });

            modelBuilder.Entity<SpecialtiyInfo>().HasData(new SpecialtiyInfo
            {
                Id = 13,
                SpecialityId = 4,
                IsDelete = false,
                CreateDate = DateTime.Now,
                LanguageId = "fa-IR",
                Title = "فوق تخصص غدد",
            });

            modelBuilder.Entity<SpecialtiyInfo>().HasData(new SpecialtiyInfo
            {
                Id = 14,
                SpecialityId = 4,
                IsDelete = false,
                CreateDate = DateTime.Now,
                LanguageId = "en-US",
                Title = "Endocrinology specialist"
            });

            modelBuilder.Entity<SpecialtiyInfo>().HasData(new SpecialtiyInfo
            {
                Id = 15,
                SpecialityId = 4,
                IsDelete = false,
                CreateDate = DateTime.Now,
                LanguageId = "tr-TR",
                Title = "endokrinoloji uzmanı"
            });

            modelBuilder.Entity<SpecialtiyInfo>().HasData(new SpecialtiyInfo
            {
                Id = 16,
                SpecialityId = 4,
                IsDelete = false,
                CreateDate = DateTime.Now,
                LanguageId = "ar-SA",
                Title = "أخصائي أمراض الغدد الصماء"
            });

            modelBuilder.Entity<SpecialtiyInfo>().HasData(new SpecialtiyInfo
            {
                Id = 17,
                SpecialityId = 5,
                IsDelete = false,
                CreateDate = DateTime.Now,
                LanguageId = "en-US",
                Title = "Cardiovascular"
            });

            modelBuilder.Entity<SpecialtiyInfo>().HasData(new SpecialtiyInfo
            {
                Id = 18,
                SpecialityId = 5,
                IsDelete = false,
                CreateDate = DateTime.Now,
                LanguageId = "fa-IR",
                Title = "قلب و عروق"
            });

            modelBuilder.Entity<SpecialtiyInfo>().HasData(new SpecialtiyInfo
            {
                Id = 19,
                SpecialityId = 5,
                IsDelete = false,
                CreateDate = DateTime.Now,
                LanguageId = "ar-SA",
                Title = "القلب والأوعية الدموية"
            });

            modelBuilder.Entity<SpecialtiyInfo>().HasData(new SpecialtiyInfo
            {
                Id = 20,
                SpecialityId = 5,
                IsDelete = false,
                CreateDate = DateTime.Now,
                LanguageId = "tr-TR",
                Title = "kardiyovasküler"
            });

            modelBuilder.Entity<SpecialtiyInfo>().HasData(new SpecialtiyInfo
            {
                Id = 21,
                SpecialityId = 6,
                IsDelete = false,
                CreateDate = DateTime.Now,
                LanguageId = "en-US",
                Title = "Cardiologist"
            });

            modelBuilder.Entity<SpecialtiyInfo>().HasData(new SpecialtiyInfo
            {
                Id = 22,
                SpecialityId = 6,
                IsDelete = false,
                CreateDate = DateTime.Now,
                LanguageId = "fa-IR",
                Title = "متخصص قلب و عروق"
            });

            modelBuilder.Entity<SpecialtiyInfo>().HasData(new SpecialtiyInfo
            {
                Id = 23,
                SpecialityId = 6,
                IsDelete = false,
                CreateDate = DateTime.Now,
                LanguageId = "ar-SA",
                Title = "طبيب قلب"
            });

            modelBuilder.Entity<SpecialtiyInfo>().HasData(new SpecialtiyInfo
            {
                Id = 24,
                SpecialityId = 6,
                IsDelete = false,
                CreateDate = DateTime.Now,
                LanguageId = "tr-TR",
                Title = "kardiyolog"
            });

            modelBuilder.Entity<SpecialtiyInfo>().HasData(new SpecialtiyInfo
            {
                Id = 25,
                SpecialityId = 7,
                IsDelete = false,
                CreateDate = DateTime.Now,
                LanguageId = "en-US",
                Title = "Cardiology specialist"
            });

            modelBuilder.Entity<SpecialtiyInfo>().HasData(new SpecialtiyInfo
            {
                Id = 26,
                SpecialityId = 7,
                IsDelete = false,
                CreateDate = DateTime.Now,
                LanguageId = "fa-IR",
                Title = "فوق تخصص قلب و عروق"
            });

            modelBuilder.Entity<SpecialtiyInfo>().HasData(new SpecialtiyInfo
            {
                Id = 27,
                SpecialityId = 7,
                IsDelete = false,
                CreateDate = DateTime.Now,
                LanguageId = "ar-SA",
                Title = "أخصائي أمراض القلب"
            });

            modelBuilder.Entity<SpecialtiyInfo>().HasData(new SpecialtiyInfo
            {
                Id = 28,
                SpecialityId = 7,
                IsDelete = false,
                CreateDate = DateTime.Now,
                LanguageId = "tr-TR",
                Title = "kardiyoloji uzmanı"
            });

            modelBuilder.Entity<SpecialtiyInfo>().HasData(new SpecialtiyInfo
            {
                Id = 29,
                SpecialityId = 8,
                IsDelete = false,
                CreateDate = DateTime.Now,
                LanguageId = "fa-IR",
                Title = "متخصص پزشک خانواده",
            });

            modelBuilder.Entity<SpecialtiyInfo>().HasData(new SpecialtiyInfo
            {
                Id = 30,
                SpecialityId = 8,
                IsDelete = false,
                CreateDate = DateTime.Now,
                LanguageId = "en-US",
                Title = "Family doctor specialist"
            });

            modelBuilder.Entity<SpecialtiyInfo>().HasData(new SpecialtiyInfo
            {
                Id = 31,
                SpecialityId = 8,
                IsDelete = false,
                CreateDate = DateTime.Now,
                LanguageId = "tr-TR",
                Title = "Aile hekimi uzmanı"
            });

            modelBuilder.Entity<SpecialtiyInfo>().HasData(new SpecialtiyInfo
            {
                Id = 32,
                SpecialityId = 8,
                IsDelete = false,
                CreateDate = DateTime.Now,
                LanguageId = "ar-SA",
                Title = "أخصائي طب الأسرة"
            });

            #endregion

            #endregion

            #region Pharmacy Interests

            #region Interests

            modelBuilder.Entity<PharmacyInterests>().HasData(new PharmacyInterests
            {
                Id = 1,
                CreateDate = DateTime.Now,
                IsDelete = false
            });

            #endregion

            #region Interests Info 

            modelBuilder.Entity<PharmacyInterestInfo>().HasData(new PharmacyInterestInfo
            {
                Id = 1,
                InterestId = 1,
                IsDelete = false,
                CreateDate = DateTime.Now,
                LanguageId = "fa-IR",
                Title = "داروخانه در منزل"
            });

            modelBuilder.Entity<PharmacyInterestInfo>().HasData(new PharmacyInterestInfo
            {
                Id = 2,
                InterestId = 1,
                IsDelete = false,
                CreateDate = DateTime.Now,
                LanguageId = "tr-TR",
                Title = "evde eczane"
            });

            modelBuilder.Entity<PharmacyInterestInfo>().HasData(new PharmacyInterestInfo
            {
                Id = 3,
                InterestId = 1,
                IsDelete = false,
                CreateDate = DateTime.Now,
                LanguageId = "ar-SA",
                Title = "صيدلية في المنزل"
            });

            modelBuilder.Entity<PharmacyInterestInfo>().HasData(new PharmacyInterestInfo
            {
                Id = 4,
                InterestId = 1,
                IsDelete = false,
                CreateDate = DateTime.Now,
                LanguageId = "en-US",
                Title = "Pharmacy at home"
            });

            #endregion

            #endregion

            #region Category Seed Data

            #region Catgeory

            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = 1,
                CreateDate = DateTime.Now,
                IsDelete = false,
                ParentId = null,
                UniqueName = "Cosmetics",
            });

            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = 2,
                CreateDate = DateTime.Now,
                IsDelete = false,
                ParentId = null,
                UniqueName = "Medical Equipment",
            });

            #endregion

            #region Category Info

            modelBuilder.Entity<CategoryInfo>().HasData(new CategoryInfo
            {
                Id = 1,
                CategoryId = 1,
                IsDelete = false,
                CreateDate = DateTime.Now,
                LanguageId = "fa-IR",
                Title = "لوازم آرایشی بهداشتی"
            });

            modelBuilder.Entity<CategoryInfo>().HasData(new CategoryInfo
            {
                Id = 2,
                CategoryId = 1,
                IsDelete = false,
                CreateDate = DateTime.Now,
                LanguageId = "en-US",
                Title = "Cosmetics"
            });

            modelBuilder.Entity<CategoryInfo>().HasData(new CategoryInfo
            {
                Id = 3,
                CategoryId = 1,
                IsDelete = false,
                CreateDate = DateTime.Now,
                LanguageId = "tr-TR",
                Title = "Makyaj malzemeleri"
            });

            modelBuilder.Entity<CategoryInfo>().HasData(new CategoryInfo
            {
                Id = 4,
                CategoryId = 1,
                IsDelete = false,
                CreateDate = DateTime.Now,
                LanguageId = "ar-SA",
                Title = "مستحضرات التجميل"
            });

            modelBuilder.Entity<CategoryInfo>().HasData(new CategoryInfo
            {
                Id = 5,
                CategoryId = 2,
                IsDelete = false,
                CreateDate = DateTime.Now,
                LanguageId = "ar-SA",
                Title = "معدات طبية"
            });

            modelBuilder.Entity<CategoryInfo>().HasData(new CategoryInfo
            {
                Id = 6,
                CategoryId = 2,
                IsDelete = false,
                CreateDate = DateTime.Now,
                LanguageId = "tr-TR",
                Title = "Tıbbi malzeme"
            });

            modelBuilder.Entity<CategoryInfo>().HasData(new CategoryInfo
            {
                Id = 7,
                CategoryId = 2,
                IsDelete = false,
                CreateDate = DateTime.Now,
                LanguageId = "en-US",
                Title = "Medical Equipment"
            });

            modelBuilder.Entity<CategoryInfo>().HasData(new CategoryInfo
            {
                Id = 8,
                CategoryId = 2,
                IsDelete = false,
                CreateDate = DateTime.Now,
                LanguageId = "fa-IR",
                Title = "تجهیزات پزشکی"
            });

            #endregion

            #endregion

            base.OnModelCreating(modelBuilder);
        }

        #endregion
    }
}
