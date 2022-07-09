using DoctorFAM.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Admin.Product
{
    public class ProductFeatureAdminViewModel
    {
        #region properties

        public List<ProductFeature> ProductFeature { get; set; }

        public ulong ProductID { get; set; }

        [MaxLength(800)]
        public string? FeatureTitle { get; set; }

        [MaxLength(450)]
        public string? FeatureValue { get; set; }

        #endregion
    }

    public enum AddProductAdminFeatureResult
    {
        Success,
        ProductNotFound,
        TitleNotFound,
        ValueNotFound
    }
}
