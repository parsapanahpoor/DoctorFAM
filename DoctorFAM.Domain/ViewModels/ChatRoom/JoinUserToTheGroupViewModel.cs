using DoctorFAM.Domain.Entities.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.ChatRoom
{
    public class JoinUserToTheGroupViewModel
    {
        #region properties

        public ChatGroup ChatGroup { get; set; }

        public List<ChatViewModel>? Chats { get; set; }

        #endregion
    }
}
