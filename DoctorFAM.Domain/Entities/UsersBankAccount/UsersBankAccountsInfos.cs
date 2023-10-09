#region Usings

using DoctorFAM.Domain.Entities.Common;
using DoctorFAM.Domain.Markers;
namespace DoctorFAM.Domain.Entities.UsersBankAccount;

#endregion

[EntityMarkerAttribute]
public sealed class UsersBankAccountsInfos : BaseEntity
{
    #region properties

    public ulong UserId { get; set; }

    public string ShomareShaba{ get; set; }

    public string ShomareCart { get; set; }

    public string BankName { get; set; }

    public string OwnerAccountUsername{ get; set; }

    public string BankBranchCode { get; set; }

    public string BankBranchName { get; set; }

    #endregion
}
