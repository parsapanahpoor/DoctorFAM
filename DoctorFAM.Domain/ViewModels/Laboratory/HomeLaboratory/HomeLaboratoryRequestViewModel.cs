#region Usings

using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Laboratory;
using DoctorFAM.Domain.Entities.Patient;
using DoctorFAM.Domain.Entities.Requests;

#endregion

namespace DoctorFAM.Domain.ViewModels.Laboratory.HomeLaboratory;

public class HomeLaboratoryRequestViewModel
{
    #region properties

    public Request Request { get; set; }

    public PaitientRequestDetail PatientRequestDetail { get; set; }

    public PatientRequestDateTimeDetail PatientRequestDateTimeDetail { get; set; }

    public Patient Patient { get; set; }

    public ICollection<HomeLaboratoryRequestDetail> HomeLaboratoryRequestDetail { get; set; }

    public User User { get; set; }

    public string? SupplementaryInsurance { get; set; }

    #endregion
}