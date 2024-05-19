using DoctorFAM.Domain.Entities.Account;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using DoctorFAM.Domain.Entities.RatingAgg;

namespace DoctorFAM.Data.ValidationsAndMappings.Rating;

public class RatingMapper : IEntityTypeConfiguration<OrganizationStart>
{
    public void Configure(EntityTypeBuilder<OrganizationStart> builder)
    {
        builder.ToTable("OrganizationsStarts");

        builder.HasKey(t => t.Id);
        builder.Property(p => p.OperatorUserId);
        builder.Property(p => p.PatientUserId);
        builder.Property(p => p.CreateDate);
        builder.Property(p => p.Star);
        builder.Property(p => p.OrganizationStartEnum);
        builder.Property(p => p.IsDelete);
    }
}