using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Common;
using DoctorFAM.Domain.Enums.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.Product
{
    public class Product : BaseEntity
    {
        #region properties

        public ulong UserId { get; set; }

        [MaxLength(450)]
        public string ProductTitle { get; set; }

        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

        [MaxLength(50)]
        public string ProductImageName { get; set; }

        public int? OfferPercent { get; set; }

        public bool? IsInOffer { get; set; }

        public decimal Price { get; set; }

        public ProductsState ProductsState { get; set; }

        public string? RejectedNote { get; set; }

        public ProductSaleType ProductSaleType { get; set; }

        public int ProductsCount { get; set; }

        public string? PackedProductsDescription { get; set; }

        #endregion

        #region relations

        public User Users { get; set; }

        public ICollection<ProductsTags> ProductsTags { get; set; }

        public ICollection<ProductSelectedCategory> ProductSelectedCategories { get; set; }

        public ICollection<ProductFeature> ProductFeatures { get; set; }

        public ICollection<ProductGallery> ProductGalleries { get; set; }

        #endregion
    }
}
