using DoctorFAM.Domain.Entities.UsersBankAccount;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoctorFAM.Data.Configuration.UserBankAccounts;

public class UserBankAccountsInfosConfig : IEntityTypeConfiguration<UsersBankAccountsInfos>
{
    public void Configure(EntityTypeBuilder<UsersBankAccountsInfos> builder)
    {
        builder.Property(p => p.ShomareCart)
               .HasMaxLength(70)
               .IsRequired();

        builder.Property(p=> p.BankName)
               .HasMaxLength(90)
               .IsRequired();
    }
}
