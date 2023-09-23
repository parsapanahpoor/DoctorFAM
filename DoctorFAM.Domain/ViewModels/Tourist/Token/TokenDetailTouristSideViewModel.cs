using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Tourism.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Tourist.Token
{
    public class TokenDetailTouristSideViewModel
    {
        #region properties

        public TouristToken TouristToken { get; set; }

        public List<ListOfPassengersInTokenDetailPage> ListOfPassengersInTokenDetailPage { get; set; }

        #endregion
    }

    public class ListOfPassengersInTokenDetailPage
    {
        #region properties

        public User? User { get; set; }

        public TouristPassengers? TouristPassengers { get; set; }

        #endregion
    }
}
