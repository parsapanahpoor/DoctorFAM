using DoctorFAM.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.Chat
{
    public class ChatGroupMember : BaseEntity
    {
        #region properties

        public ulong UserId { get; set; }

        public ulong GroupId { get; set; }

        #endregion

        #region relation

        #endregion
    }
}
