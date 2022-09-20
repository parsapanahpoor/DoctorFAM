using DoctorFAM.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Interfaces
{
    public interface ITicketService
    {
        #region Doctor Side 

        //Create Tikcet For First Time After Accept Online Visit Request From Doctor 
        Task<bool> AddTicketForFirstTimeInOnlineVisitInDoctorPanel(Request request);

        #endregion
    }
}
