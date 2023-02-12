using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.HealthInformation;
using DoctorFAM.Domain.Entities.Interest;
using DoctorFAM.Domain.Entities.Languages;
using DoctorFAM.Domain.Entities.MarketCategory;
using DoctorFAM.Domain.Entities.SiteSetting;
using DoctorFAM.Domain.Entities.Speciality;
using DoctorFAM.Domain.Entities.States;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DoctorFAM.Convertors.Context
{
    public class NewContext : DbContext
    {
        #region Constructor

        public NewContext()
        {

        }

        public NewContext(DbContextOptions<NewContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-CM9A86V\\MSSQL2019;Initial Catalog=DoctorFAMDb14011122;Integrated Security=True");
            }
        }

        #endregion

        #region Account 

        public DbSet<User> Users { get; set; }

        #endregion

        #region On Model Creating

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            #region Insurance Seed Data 

            //modelBuilder.Entity<Insurance>().HasData(new Insurance
            //{
            //    Id = 1,
            //    CreateDate = DateTime.Now,
            //    IsDelete = false,
            //    Title = "بیمه سلامت"
            //});

            //modelBuilder.Entity<Insurance>().HasData(new Insurance
            //{
            //    Id = 2,
            //    CreateDate = DateTime.Now,
            //    IsDelete = false,
            //    Title = "بیمه ی تامین اجتماعی"
            //});

            //modelBuilder.Entity<Insurance>().HasData(new Insurance
            //{
            //    Id = 3,
            //    CreateDate = DateTime.Now,
            //    IsDelete = false,
            //    Title = "مشاغل آزاد"
            //});

            //modelBuilder.Entity<Insurance>().HasData(new Insurance
            //{
            //    Id = 4,
            //    CreateDate = DateTime.Now,
            //    IsDelete = false,
            //    Title = "بیمه ی ایرانیان"
            //});

            //modelBuilder.Entity<Insurance>().HasData(new Insurance
            //{
            //    Id = 5,
            //    CreateDate = DateTime.Now,
            //    IsDelete = false,
            //    Title = "آزاد"
            //});

            #endregion

            base.OnModelCreating(modelBuilder);
        }

        #endregion
    }
}
