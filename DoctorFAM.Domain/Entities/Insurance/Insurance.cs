#region Usings

using DoctorFAM.Domain.Entities.Common;

# endregion

namespace DoctorFAM.Domain.Entities.Insurance;

public class Insurance: BaseEntity
{
    #region properties

    public string Title { get; set; }

    #endregion

    #region properties

    public ICollection<Patient.Patient> Patients { get; set; }

    public ICollection<PopulationCovered.PopulationCovered> PopulationCovered { get; set; }

    #endregion
}
