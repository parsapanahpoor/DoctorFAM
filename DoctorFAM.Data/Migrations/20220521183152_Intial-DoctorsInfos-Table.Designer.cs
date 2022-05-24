﻿// <auto-generated />
using System;
using DoctorFAM.Data.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DoctorFAM.Data.Migrations
{
    [DbContext(typeof(DoctorFAMDbContext))]
    [Migration("20220521183152_Intial-DoctorsInfos-Table")]
    partial class IntialDoctorsInfosTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DoctorFAM.DataLayer.Entities.Request", b =>
                {
                    b.Property<decimal>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(20,0)");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<decimal>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<decimal?>("PatientId")
                        .HasColumnType("decimal(20,0)");

                    b.Property<int>("RequestState")
                        .HasColumnType("int");

                    b.Property<int>("RequestType")
                        .HasColumnType("int");

                    b.Property<decimal>("UserId")
                        .HasColumnType("decimal(20,0)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("DoctorFAM.Domain.Entities.Account.Role", b =>
                {
                    b.Property<decimal>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(20,0)");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<decimal>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("RoleUniqueName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1m,
                            CreateDate = new DateTime(2022, 5, 21, 23, 1, 51, 889, DateTimeKind.Local).AddTicks(7461),
                            IsDelete = false,
                            RoleUniqueName = "Admin",
                            Title = "Admin"
                        },
                        new
                        {
                            Id = 2m,
                            CreateDate = new DateTime(2022, 5, 21, 23, 1, 51, 889, DateTimeKind.Local).AddTicks(7479),
                            IsDelete = false,
                            RoleUniqueName = "Doctor",
                            Title = "Doctor"
                        },
                        new
                        {
                            Id = 3m,
                            CreateDate = new DateTime(2022, 5, 21, 23, 1, 51, 889, DateTimeKind.Local).AddTicks(7489),
                            IsDelete = false,
                            RoleUniqueName = "Support",
                            Title = "Support"
                        });
                });

            modelBuilder.Entity("DoctorFAM.Domain.Entities.Account.RolePermission", b =>
                {
                    b.Property<decimal>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(20,0)");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<decimal>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<decimal>("PermissionId")
                        .HasColumnType("decimal(20,0)");

                    b.Property<decimal>("RoleId")
                        .HasColumnType("decimal(20,0)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RolePermissions");
                });

            modelBuilder.Entity("DoctorFAM.Domain.Entities.Account.User", b =>
                {
                    b.Property<decimal>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(20,0)");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<decimal>("Id"), 1L, 1);

                    b.Property<string>("Avatar")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("BanForComment")
                        .HasColumnType("bit");

                    b.Property<bool>("BanForTicket")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("EmailActivationCode")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<bool>("IsBan")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<bool>("IsEmailConfirm")
                        .HasColumnType("bit");

                    b.Property<bool>("IsMobileConfirm")
                        .HasColumnType("bit");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("MobileActivationCode")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int>("WalletBalance")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DoctorFAM.Domain.Entities.Account.UserRole", b =>
                {
                    b.Property<decimal>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(20,0)");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<decimal>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<decimal>("RoleId")
                        .HasColumnType("decimal(20,0)");

                    b.Property<decimal>("UserId")
                        .HasColumnType("decimal(20,0)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("DoctorFAM.Domain.Entities.Doctors.DoctorsInfo", b =>
                {
                    b.Property<decimal>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(20,0)");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<decimal>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DoctorsInfosType")
                        .HasColumnType("int");

                    b.Property<string>("Education")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("MediacalFile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MedicalSystemCode")
                        .HasColumnType("int");

                    b.Property<int>("NationalCode")
                        .HasColumnType("int");

                    b.Property<string>("OfficeFile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RejectDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Specialty")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("UserId")
                        .HasColumnType("decimal(20,0)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("DoctorsInfos");
                });

            modelBuilder.Entity("DoctorFAM.Domain.Entities.Languages.Language", b =>
                {
                    b.Property<string>("SystemName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("SystemName");

                    b.ToTable("languages");

                    b.HasData(
                        new
                        {
                            SystemName = "en-US",
                            IsActive = true,
                            Title = "English"
                        },
                        new
                        {
                            SystemName = "fa-IR",
                            IsActive = true,
                            Title = "فارسی"
                        },
                        new
                        {
                            SystemName = "tr-TR",
                            IsActive = true,
                            Title = "Turkish"
                        },
                        new
                        {
                            SystemName = "ar-SA",
                            IsActive = true,
                            Title = "Arabic"
                        });
                });

            modelBuilder.Entity("DoctorFAM.Domain.Entities.Patient.Patient", b =>
                {
                    b.Property<decimal>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(20,0)");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<decimal>("Id"), 1L, 1);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<int>("InsuranceType")
                        .HasColumnType("int");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("NationalId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("PatientId")
                        .HasColumnType("decimal(20,0)");

                    b.Property<string>("PatientLastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PatientName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RequestDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("RequestId")
                        .HasColumnType("decimal(20,0)");

                    b.Property<decimal>("UserId")
                        .HasColumnType("decimal(20,0)");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.HasIndex("RequestId");

                    b.HasIndex("UserId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("DoctorFAM.Domain.Entities.Pharmacy.HomePharmacyRequestDetail", b =>
                {
                    b.Property<decimal>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(20,0)");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<decimal>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DrugCount")
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<string>("DrugImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DrugName")
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<string>("DrugPrescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DrugTrakingCode")
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<decimal>("RequestId")
                        .HasColumnType("decimal(20,0)");

                    b.HasKey("Id");

                    b.HasIndex("RequestId");

                    b.ToTable("HomePharmacyRequestDetails");
                });

            modelBuilder.Entity("DoctorFAM.Domain.Entities.Requests.PaitientRequestDetail", b =>
                {
                    b.Property<decimal>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(20,0)");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<decimal>("Id"), 1L, 1);

                    b.Property<decimal>("CityId")
                        .HasColumnType("decimal(20,0)");

                    b.Property<decimal>("CountryId")
                        .HasColumnType("decimal(20,0)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Distance")
                        .HasColumnType("int");

                    b.Property<string>("FullAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PatientId")
                        .HasColumnType("decimal(20,0)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("RequestId")
                        .HasColumnType("decimal(20,0)");

                    b.Property<decimal>("StateId")
                        .HasColumnType("decimal(20,0)");

                    b.Property<string>("Vilage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("CountryId");

                    b.HasIndex("PatientId");

                    b.HasIndex("RequestId")
                        .IsUnique();

                    b.HasIndex("StateId");

                    b.ToTable("PaitientRequestDetails");
                });

            modelBuilder.Entity("DoctorFAM.Domain.Entities.Requests.PatientRequestDateTimeDetail", b =>
                {
                    b.Property<decimal>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(20,0)");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<decimal>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("EndTime")
                        .HasColumnType("int");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<decimal>("RequestId")
                        .HasColumnType("decimal(20,0)");

                    b.Property<DateTime>("SendDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("StartTime")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RequestId");

                    b.ToTable("PatientRequestDateTimeDetails");
                });

            modelBuilder.Entity("DoctorFAM.Domain.Entities.SiteSetting.EmailSetting", b =>
                {
                    b.Property<decimal>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(20,0)");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<decimal>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("EnableSsL")
                        .HasColumnType("bit");

                    b.Property<string>("From")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("IsDefaultEmail")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Port")
                        .HasColumnType("int");

                    b.Property<string>("Smtp")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("EmailSettings");

                    b.HasData(
                        new
                        {
                            Id = 1m,
                            CreateDate = new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DisplayName = "DoctorFAm",
                            EnableSsL = true,
                            From = "maghsoudlou.reza@gmail.com",
                            IsDefaultEmail = true,
                            IsDelete = false,
                            Password = "Reza@83040697",
                            Port = 587,
                            Smtp = "smtp.gmail.com",
                            UserName = "DoctorFAm"
                        });
                });

            modelBuilder.Entity("DoctorFAM.Domain.Entities.States.Location", b =>
                {
                    b.Property<decimal>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(20,0)");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<decimal>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<decimal?>("ParentId")
                        .HasColumnType("decimal(20,0)");

                    b.Property<string>("UniqueName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("DoctorFAM.Domain.Entities.States.LocationInfo", b =>
                {
                    b.Property<decimal>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(20,0)");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<decimal>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("LanguageId")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal>("LocationId")
                        .HasColumnType("decimal(20,0)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.HasIndex("LocationId");

                    b.ToTable("LocationInfoes");
                });

            modelBuilder.Entity("DoctorFAM.Domain.Entities.Wallet.Wallet", b =>
                {
                    b.Property<decimal>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(20,0)");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<decimal>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("GatewayType")
                        .HasColumnType("int");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<bool>("IsFinally")
                        .HasColumnType("bit");

                    b.Property<int>("PaymentType")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("TransactionType")
                        .HasColumnType("int");

                    b.Property<int>("TransactionWay")
                        .HasColumnType("int");

                    b.Property<decimal>("UserId")
                        .HasColumnType("decimal(20,0)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Wallets");
                });

            modelBuilder.Entity("DoctorFAM.Domain.Entities.Wallet.WalletData", b =>
                {
                    b.Property<decimal>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(20,0)");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<decimal>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("GatewayType")
                        .HasColumnType("int");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("ReferenceCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrackingCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("WalletId")
                        .HasColumnType("decimal(20,0)");

                    b.HasKey("Id");

                    b.HasIndex("WalletId")
                        .IsUnique();

                    b.ToTable("WalletData");
                });

            modelBuilder.Entity("DoctorFAM.DataLayer.Entities.Request", b =>
                {
                    b.HasOne("DoctorFAM.Domain.Entities.Account.User", "User")
                        .WithMany("Requests")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DoctorFAM.Domain.Entities.Account.RolePermission", b =>
                {
                    b.HasOne("DoctorFAM.Domain.Entities.Account.Role", "Role")
                        .WithMany("RolePermissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("DoctorFAM.Domain.Entities.Account.UserRole", b =>
                {
                    b.HasOne("DoctorFAM.Domain.Entities.Account.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DoctorFAM.Domain.Entities.Account.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DoctorFAM.Domain.Entities.Doctors.DoctorsInfo", b =>
                {
                    b.HasOne("DoctorFAM.Domain.Entities.Account.User", "User")
                        .WithMany("DoctorsInfos")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DoctorFAM.Domain.Entities.Patient.Patient", b =>
                {
                    b.HasOne("DoctorFAM.DataLayer.Entities.Request", null)
                        .WithMany("Patient")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DoctorFAM.DataLayer.Entities.Request", "Request")
                        .WithMany()
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DoctorFAM.Domain.Entities.Account.User", "User")
                        .WithMany("Patients")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Request");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DoctorFAM.Domain.Entities.Pharmacy.HomePharmacyRequestDetail", b =>
                {
                    b.HasOne("DoctorFAM.DataLayer.Entities.Request", "Request")
                        .WithMany("HomePharmacyRequestDetails")
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Request");
                });

            modelBuilder.Entity("DoctorFAM.Domain.Entities.Requests.PaitientRequestDetail", b =>
                {
                    b.HasOne("DoctorFAM.Domain.Entities.States.Location", "City")
                        .WithMany("PaitientRequestDetailCities")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DoctorFAM.Domain.Entities.States.Location", "Country")
                        .WithMany("PaitientRequestDetailCountries")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DoctorFAM.Domain.Entities.Patient.Patient", "Patient")
                        .WithMany("PaitientRequestDetails")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DoctorFAM.DataLayer.Entities.Request", "Request")
                        .WithOne("PaitientRequestDetails")
                        .HasForeignKey("DoctorFAM.Domain.Entities.Requests.PaitientRequestDetail", "RequestId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DoctorFAM.Domain.Entities.States.Location", "State")
                        .WithMany("PaitientRequestDetailStates")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("Country");

                    b.Navigation("Patient");

                    b.Navigation("Request");

                    b.Navigation("State");
                });

            modelBuilder.Entity("DoctorFAM.Domain.Entities.Requests.PatientRequestDateTimeDetail", b =>
                {
                    b.HasOne("DoctorFAM.DataLayer.Entities.Request", "Requests")
                        .WithMany("PatientRequestDateTimeDetails")
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Requests");
                });

            modelBuilder.Entity("DoctorFAM.Domain.Entities.States.Location", b =>
                {
                    b.HasOne("DoctorFAM.Domain.Entities.States.Location", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("DoctorFAM.Domain.Entities.States.LocationInfo", b =>
                {
                    b.HasOne("DoctorFAM.Domain.Entities.Languages.Language", "Language")
                        .WithMany("MyProperty")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DoctorFAM.Domain.Entities.States.Location", "Location")
                        .WithMany("LocationsInfo")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Language");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("DoctorFAM.Domain.Entities.Wallet.Wallet", b =>
                {
                    b.HasOne("DoctorFAM.Domain.Entities.Account.User", "User")
                        .WithMany("Wallets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DoctorFAM.Domain.Entities.Wallet.WalletData", b =>
                {
                    b.HasOne("DoctorFAM.Domain.Entities.Wallet.Wallet", "Wallet")
                        .WithOne("WalletData")
                        .HasForeignKey("DoctorFAM.Domain.Entities.Wallet.WalletData", "WalletId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Wallet");
                });

            modelBuilder.Entity("DoctorFAM.DataLayer.Entities.Request", b =>
                {
                    b.Navigation("HomePharmacyRequestDetails");

                    b.Navigation("PaitientRequestDetails")
                        .IsRequired();

                    b.Navigation("Patient");

                    b.Navigation("PatientRequestDateTimeDetails");
                });

            modelBuilder.Entity("DoctorFAM.Domain.Entities.Account.Role", b =>
                {
                    b.Navigation("RolePermissions");
                });

            modelBuilder.Entity("DoctorFAM.Domain.Entities.Account.User", b =>
                {
                    b.Navigation("DoctorsInfos");

                    b.Navigation("Patients");

                    b.Navigation("Requests");

                    b.Navigation("UserRoles");

                    b.Navigation("Wallets");
                });

            modelBuilder.Entity("DoctorFAM.Domain.Entities.Languages.Language", b =>
                {
                    b.Navigation("MyProperty");
                });

            modelBuilder.Entity("DoctorFAM.Domain.Entities.Patient.Patient", b =>
                {
                    b.Navigation("PaitientRequestDetails");
                });

            modelBuilder.Entity("DoctorFAM.Domain.Entities.States.Location", b =>
                {
                    b.Navigation("LocationsInfo");

                    b.Navigation("PaitientRequestDetailCities");

                    b.Navigation("PaitientRequestDetailCountries");

                    b.Navigation("PaitientRequestDetailStates");
                });

            modelBuilder.Entity("DoctorFAM.Domain.Entities.Wallet.Wallet", b =>
                {
                    b.Navigation("WalletData")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
