using DoctorFAM.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.Product
{
    public class ProductSelectedCategory : BaseEntity
    {
        #region properties

        public ulong ProductCategoryId { get; set; }

        public ulong ProductID { get; set; }

        #endregion

        #region relations

        [ForeignKey("ProductCategoryId")]
        public MarketCategory.Category ProductCategory { get; set; }

        public Product Product { get; set; }

        #endregion
    }
}
