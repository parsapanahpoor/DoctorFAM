using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.Requests
{
    public class RequestTransferingPriceFromOperator : BaseEntity
    {
        #region properties

        public ulong RequestId { get; set; }

        public int Price { get; set; }

        #endregion

        #region relations

        public Request Request { get; set; }

        #endregion
    }
}
