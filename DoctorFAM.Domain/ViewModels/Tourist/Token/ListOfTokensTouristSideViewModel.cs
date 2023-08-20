using DoctorFAM.Domain.Enums.Tourist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Tourist.Token
{
    public class ListOfTokensTouristSideViewModel
    {
        #region properties

        public string TokenCode { get; set; }

        public string? TokenLabel { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int CountOfPassengers { get; set; }

        public TouristTokenState TouristTokenState { get; set; }

        #endregion
    }
}
