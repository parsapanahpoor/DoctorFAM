namespace DoctorFAM.Application.DTOs.DoctorPanel.DoctorsBanksAccounts;

public record ListOfDoctorBankAccountsInfosDoctorSideDTO
{
    #region properties

    public ulong Id { get; set; }

    public string ShomareShaba { get; set; }

    public string ShomareCart { get; set; }

    public string BankName { get; set; }

    #endregion
}
