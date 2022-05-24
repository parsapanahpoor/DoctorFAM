using BusinessPortal.Application.Services.Implementation;
using DoctorFAM.Application.Interfaces;
using DoctorFAM.Application.Services;
using DoctorFAM.Application.Services.Implementation;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Data.Repository;
using DoctorFAM.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.IoC
{
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

            #endregion

            #region Repository

            

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

            #endregion
        }
    }
}
