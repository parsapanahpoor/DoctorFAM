using DoctorFAM.Domain.Entities.Common;
using DoctorFAM.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.MarketCategory
{
    public class Category : BaseEntity
    {
        #region properties

        [MaxLength(200)]
        [Required]
        public string UniqueName { get; set; }

        public bool IsDelete { get; set; }

        public ulong? ParentId { get; set; }

        #endregion

        #region relation

        public Category Parent { get; set; }

        public ICollection<CategoryInfo> CategoryInfo { get; set; }

        public ICollection<ProductSelectedCategory> ProductSelectedCategories { get; set; }

        #endregion
    }
}
