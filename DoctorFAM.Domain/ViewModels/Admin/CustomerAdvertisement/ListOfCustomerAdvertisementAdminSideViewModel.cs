using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Advertisement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Admin.CustomerAdvertisement
{
    public class ListOfCustomerAdvertisementAdminSideViewModel
    {
        #region properties

        public User User { get; set; }

        public DoctorFAM.Domain.Entities.Advertisement.CustomerAdvertisement CustomerAdvertisement { get; set; }

        #endregion
    }
}
