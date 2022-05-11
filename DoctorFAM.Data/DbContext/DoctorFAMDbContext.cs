using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Languages;
using DoctorFAM.Domain.Entities.Patient;
using DoctorFAM.Domain.Entities.Pharmacy;
using DoctorFAM.Domain.Entities.Requests;
using DoctorFAM.Domain.Entities.SiteSetting;
using DoctorFAM.Domain.Entities.States;
using DoctorFAM.Domain.Entities.Wallet;
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

        #endregion

        #region Patient

        public DbSet<Patient> Patients { get; set; }

        #endregion

        #region Request

        public DbSet<Request> Requests { get; set; }

        public DbSet<PaitientRequestDetail> PaitientRequestDetails { get; set; }

        public DbSet<PatientRequestDateTimeDetail>  PatientRequestDateTimeDetails { get; set; }

        #endregion

        #region Language

        public DbSet<Language> languages { get; set; }

        #endregion

        #region Location

        public DbSet<Location> Locations { get; set; }

        public DbSet<LocationInfo> LocationInfoes { get; set; }

        #endregion

        #region Pharmacy

        public DbSet<HomePharmacyRequestDetail> HomePharmacyRequestDetails { get; set; }

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

            #endregion

            #region query filter

            modelBuilder.Entity<LocationInfo>().HasQueryFilter(e => e.LanguageId == culture);

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

            base.OnModelCreating(modelBuilder);
        }

        #endregion
    }
}
