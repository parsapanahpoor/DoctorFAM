#region Usings

using DoctorFAM.Domain.Entities.Tourism.Token;
using DoctorFAM.Domain.ViewModels.Tourist.Token;

namespace DoctorFAM.Domain.ViewModels.Admin.Tourist;

#endregion

public class TokenDetailAdminSideViewModel
{
    #region properties

    public TouristToken TouristToken { get; set; }

    public List<ListOfPassengersInTokenDetailPage> ListOfPassengersInTokenDetailPage { get; set; }

    #endregion
}