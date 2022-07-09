using DoctorFAM.Domain.Enums.Products;
using DoctorFAM.Domain.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.MarketPanel.Product
{
    public class FilterProductMarketSideViewModel : BasePaging<Entities.Product.Product>
    {
        #region Ctor

        public FilterProductMarketSideViewModel()
        {
            ProductsState = ProductsStateForFilterInPanel.All;
            ProductSaleType = ProductSaleTypeForFilterInPanel.All;
            FilterProductOrder = FilterProductOrder.CreateDate_Des;
        }

        #endregion

        #region properties

        public string? Title { get; set; }

        public int? Price  { get; set; }

        public ulong UserId { get; set; }

        public ProductsStateForFilterInPanel ProductsState { get; set; }

        public ProductSaleTypeForFilterInPanel ProductSaleType { get; set; }

        public FilterProductOrder FilterProductOrder { get; set; }

        #endregion
    }
}
