namespace DoctorFAM.Domain.ViewModels.DoctorPanel.DoctorBankAccounts;

public record ListOfDoctorBankAccountsInfosDoctorSideDTO
{
    #region properties

    public ulong Id { get; set; }

    public string ShomareShaba { get; set; }

    public string ShomareCart { get; set; }

    public string BankName { get; set; }

    #endregion
}
