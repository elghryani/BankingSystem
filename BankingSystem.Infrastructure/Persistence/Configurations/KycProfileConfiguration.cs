using BankingSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingSystem.Infrastructure.Persistence.Configurations
{
    public class KycProfileConfiguration : IEntityTypeConfiguration<KycProfile>
    {
        public void Configure(EntityTypeBuilder<KycProfile> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.IdentityNumber)
                .IsRequired()
                .HasMaxLength(15);

            builder.HasIndex(x => x.IdentityNumber)
                .IsUnique();

            builder.Property(x => x.DateOfBirth)
                .IsRequired();

            builder.Property(x => x.Address)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.SourceOfIncome)
                .IsRequired()
                .HasConversion<string>();

            builder.Property(x => x.KYCStatus)
                .IsRequired()
                .HasConversion<string>();

            builder.Property(x => x.SubmittedAt)
                .IsRequired();

            builder.Property(x => x.VerifiedAt);

            builder.HasOne(x => x.Customer)
                .WithOne(x => x.Profile)
                .HasForeignKey<KycProfile>(x => x.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
