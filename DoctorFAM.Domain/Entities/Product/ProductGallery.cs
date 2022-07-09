using DoctorFAM.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.Product
{
    public class ProductGallery : BaseEntity
    {
        #region properties

        public ulong ProductID { get; set; }

        [MaxLength(800)]
        public string Title { get; set; }

        [MaxLength(50)]
        public string ImageName { get; set; }

        #endregion

        #region relation

        public Product Product { get; set; }

        #endregion
    }
}
