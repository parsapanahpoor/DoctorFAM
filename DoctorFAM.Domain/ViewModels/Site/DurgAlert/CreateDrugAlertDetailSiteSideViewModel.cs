using DoctorFAM.Domain.Entities.DurgAlert;

namespace DoctorFAM.Domain.ViewModels.Site.DurgAlert
{
    public class CreateDrugAlertDetailSiteSideViewModel
    {
        #region properties

        public ulong CreatedDrugAlertId { get; set; }

        public DrugAlert? DrugAlert { get; set; }

        public List<int>? Hour{ get; set; }

        public List<string>? DateTime { get; set; }

        #endregion
    }
}
