﻿using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.ViewModels.Site.Doctor.Resume.Certificate;
using DoctorFAM.Domain.ViewModels.Site.Doctor.Resume.Gallery;
using DoctorFAM.Domain.ViewModels.Site.Doctor.Resume.Honor;
using DoctorFAM.Domain.ViewModels.Site.Doctor.Resume.Service;
using DoctorFAM.Domain.ViewModels.Site.Doctor.Resume.WorkHistory;
using DoctorFAM.Domain.ViewModels.Site.Doctor.Resume.WorkingAddress;
using DoctorFAM.Domain.ViewModels.Site.Doctor.Resume;
using DoctorFAM.Domain.ViewModels.Site.Doctor.Resume.Education;

namespace DoctorFAM.Domain.ViewModels.Site.Doctor;

public class DoctorPageInReservationViewModel
{
    #region properties

    public string Username { get; set; }

    public ulong UserId { get; set; }

    public string? UserAvatar { get; set; }

    public string? Specialist { get; set; }

    public string? Education { get; set; }

    public string? CountryName { get; set; }

    public string? CityName { get; set; }

    public string? StateName { get; set; }

    public string? WorkAddress { get; set; }
   
    public string? ClinicPhone { get; set; }
   
    public string? GeneralPhone { get; set; }

    public Domain.Entities.Resume.Resume Resume { get; set; }

    public User User { get; set; }

    public ResumeAboutMeSitePanelViewModel ResumeAboutMeSitePanelViewModel { get; set; }

    public List<EducationResumeInSitePanelViewModel>? EducationResume { get; set; }

    public List<WorkHistoryResumeInSitePanelViewModel>? WorkHistoryResume { get; set; }

    public List<HonorResumeInSitePanelViewModel>? HonorResume { get; set; }

    public List<ServiceResumeInSitePanelViewModel>? ServiceResume { get; set; }

    public List<WorkingAddressResumeInSitePanelViewModel>? WorkingAddressResume { get; set; }

    public List<CertificateResumeInSitePanelViewModel>? CertificateResume { get; set; }

    public List<GalleryResumeInSitePanelViewModel>? GalleryResume { get; set; }

    #endregion
}
