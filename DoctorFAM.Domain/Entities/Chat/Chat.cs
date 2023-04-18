using DoctorFAM.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.Chat
{
    public class Chat : BaseEntity
    {
        #region properties

        public string ChatBody { get; set; }

        public string? FileAttach { get; set; }

        public ulong UserId { get; set; }

        public ulong GroupId { get; set; }

        #endregion

        #region relations



        #endregion
    }
}
