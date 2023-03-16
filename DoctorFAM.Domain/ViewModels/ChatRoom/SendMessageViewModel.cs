using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.ChatRoom
{
    public class SendMessageViewModel
    {
        #region properties

        public string ChatBody { get; set; }

        public ulong UserId { get; set; }

        public ulong GroupId { get; set; }

        public string CreateDate { get; set; }

        #endregion
    }
}
