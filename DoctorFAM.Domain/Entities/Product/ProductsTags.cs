using DoctorFAM.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.Product
{
    public class ProductsTags : BaseEntity
    {
        #region properties

        public ulong ProductId { get; set; }

        [Required]
        public string TagTitle { get; set; }

        #endregion

        #region relations

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        #endregion
    }
}
