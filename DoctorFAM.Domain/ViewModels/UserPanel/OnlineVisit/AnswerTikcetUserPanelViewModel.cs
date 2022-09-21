using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DoctorFAM.Domain.ViewModels.UserPanel.OnlineVisit
{
    public class AnswerTikcetUserPanelViewModel
    {
        #region properties

        public ulong TicketId { get; set; }

        [Display(Name = "متن پیام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Message { get; set; }

        public IFormFile? MessageFile { get; set; }

        #endregion
    }
}
