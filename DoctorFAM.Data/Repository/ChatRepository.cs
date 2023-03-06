using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Interfaces.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Data.Repository
{
    public class ChatRepository : IChatRepository
    {
        #region Ctor 

        private readonly DoctorFAMDbContext _context;

        public ChatRepository(DoctorFAMDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Chat Room Area 

        //Add Group To The Data Base 

        #endregion
    }
}
