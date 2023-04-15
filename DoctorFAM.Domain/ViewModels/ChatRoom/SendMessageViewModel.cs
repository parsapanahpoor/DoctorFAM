using Microsoft.AspNetCore.Http;
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

        public string Username { get; set; }

        public ulong GroupId { get; set; }

        public string GroupName { get; set; }

        public string CreateDate { get; set; }

        public IFormFile? FileAttach { get; set; }

        #endregion
    }
}
