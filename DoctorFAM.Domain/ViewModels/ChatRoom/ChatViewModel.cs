using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.ChatRoom
{
    public class ChatViewModel 
    {
        #region properties

        public ulong UserId { get; set; }

        public ulong GroupId { get; set; }

        public string ChatBody { get; set; }

        public string UserName { get; set; }

        public string GroupName { get; set; }

        public string CreateDate { get; set; }

        #endregion
    }
}
