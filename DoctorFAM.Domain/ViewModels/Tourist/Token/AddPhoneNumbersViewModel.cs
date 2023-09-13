using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Tourist.Token;

public class AddPhoneNumbersViewModel
{
    #region properties

    public string PhoneNumber { get; set; }

    public int RequiredAmount { get; set; }

    public ulong TokenId { get; set; }

    #endregion
}

public class AddPhoneNumbersResultViewModel
{
    #region properties

    public bool Result { get; set; }

    public ulong TokenId { get; set; }

    #endregion
}
