using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Interfaces.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Implementation
{
    public class ChatService : IChatService
    {
        #region Ctor

        private readonly IChatRepository _chatRepository;

        public ChatService(IChatRepository chatRepository)
        {
            _chatRepository = chatRepository;
        }

        #endregion

        #region Chat Room Area 



        #endregion
    }
}
