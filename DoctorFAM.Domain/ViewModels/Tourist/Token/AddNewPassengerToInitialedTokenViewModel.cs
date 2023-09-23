using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Tourist.Token
{
    public class AddNewPassengerToInitialedTokenViewModel
    {
        #region properties

        public ulong  TokenId { get; set; }

        public string MobileNumber{ get; set; }

        public int RequiredAmount { get; set; }

        #endregion
    }
}
