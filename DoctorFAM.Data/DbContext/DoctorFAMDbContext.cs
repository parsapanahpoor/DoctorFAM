using Academy.Domain.Entities.SiteSetting;
using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.DoctorReservation;
using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.Interest;
using DoctorFAM.Domain.Entities.Laboratory;
using DoctorFAM.Domain.Entities.Languages;
using DoctorFAM.Domain.Entities.MarketCategory;
using DoctorFAM.Domain.Entities.Organization;
using DoctorFAM.Domain.Entities.Patient;
using DoctorFAM.Domain.Entities.Pharmacy;
using DoctorFAM.Domain.Entities.PopulationCovered;
using DoctorFAM.Domain.Entities.Product;
using DoctorFAM.Domain.Entities.Requests;
using DoctorFAM.Domain.Entities.SiteSetting;
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

        #region Account 

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        #endregion

        #region Wallet

        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<WalletData> WalletData { get; set; }

        #endregion

        #region Email Setting

        public DbSet<EmailSetting> EmailSettings { get; set; }

        public DbSet<SiteSetting> SiteSettings { get; set; }

        #endregion

        #region Patient

        public DbSet<Patient> Patients { get; set; }

        #endregion

        #region Request

        public DbSet<Request> Requests { get; set; }

        public DbSet<PaitientRequestDetail> PaitientRequestDetails { get; set; }

        public DbSet<PatientRequestDateTimeDetail> PatientRequestDateTimeDetails { get; set; }

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

        #endregion

        #region Pharmacy

        public DbSet<Pharmacy> Pharmacies { get; set; }

        public DbSet<PharmacyInfo> PharmacyInfos { get; set; }

        public DbSet<PharmacySelectedInterests> PharmacySelectedInterests { get; set; }

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

            #region Role Seed Data

            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = 1,
                Title = "Admin",
                RoleUniqueName = "Admin",
                CreateDate = DateTime.Now,
                IsDelete = false
            });

            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = 2,
                Title = "Doctor",
                RoleUniqueName = "Doctor",
                CreateDate = DateTime.Now,
                IsDelete = false
            });

            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = 3,
                Title = "Support",
                RoleUniqueName = "Support",
                CreateDate = DateTime.Now,
                IsDelete = false
            });

            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = 4,
                Title = "Seller",
                RoleUniqueName = "Seller",
                CreateDate = DateTime.Now,
                IsDelete = false
            });

            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = 5,
                Title = "DoctorOfficeEmployee",
                RoleUniqueName = "DoctorOfficeEmployee",
                CreateDate = DateTime.Now,
                IsDelete = false
            });

            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = 6,
                Title = "Pharmacy",
                RoleUniqueName = "Pharmacy",
                CreateDate = DateTime.Now,
                IsDelete = false
            });

            #endregion

            #endregion

            #region query filter

            modelBuilder.Entity<LocationInfo>().HasQueryFilter(e => e.LanguageId == culture);

            modelBuilder.Entity<CategoryInfo>().HasQueryFilter(e => e.LanguageId == culture);

            modelBuilder.Entity<DoctorsInterestInfo>().HasQueryFilter(e => e.LanguageId == culture);

            modelBuilder.Entity<PharmacyInterestInfo>().HasQueryFilter(e => e.LanguageId == culture);

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
