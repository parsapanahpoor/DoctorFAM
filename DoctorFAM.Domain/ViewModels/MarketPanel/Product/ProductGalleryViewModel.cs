using DoctorFAM.Domain.Entities.Product;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.MarketPanel.Product
{
    public class ProductGalleryViewModel
    {
        #region properties

        public List<ProductGallery> ProductGallery { get; set; }

        [MaxLength(800)]
        public string? Title { get; set; }

        public IFormFile? ImageName { get; set; }

        public ulong ProductId { get; set; }

        #endregion
    }

    public enum AddProductGalleryResult
    {
        Success,
        Faild,
        TitleNotFound,
        ProductNotFound,
        ImageNotFound
    }
}
