using DoctorFAM.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.Chat
{
    public class ChatGroup : BaseEntity
    {
        #region properties

        [MaxLength(100)]
        public string GroupTitle { get; set; }

        [MaxLength(110)]
        public string GroupToken { get; set; }

        public string ImageName { get; set; }

        public ulong OwnerId { get; set; }

        #endregion

        #region relations



        #endregion
    }
}
