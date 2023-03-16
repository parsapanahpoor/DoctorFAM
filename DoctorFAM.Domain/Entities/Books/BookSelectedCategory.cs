using DoctorFAM.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.Books
{
    public class BookSelectedCategory:BaseEntity
    {
        #region Properties

        public ulong BookId { get; set; }

        public ulong BookCategoryId { get; set; }

        #endregion

        #region Relations

        public BookCategory BookCategory { get; set; }

        public Book Book { get; set; }

        #endregion
    }
}
