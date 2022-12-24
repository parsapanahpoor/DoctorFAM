using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorFAM.Domain.Entities.Common;

namespace DoctorFAM.Domain.Entities.News
{
    public class NewsSelectedCategory : BaseEntity
    {
        #region Properties

        public ulong NewsId { get; set; }

        public ulong NewsCategoryId { get; set; }

        #endregion

        #region Relations

        public NewsCategory NewsCategory { get; set; }

        public News News { get; set; }

        #endregion
    }
}
