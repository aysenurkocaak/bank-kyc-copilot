using BankKycCopilot.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankKycCopilot.Infrastructure.Persistence.Configurations;

public class ApplicationConfiguration : IEntityTypeConfiguration<BankKycCopilot.Domain.Entities.Application>
{
    public void Configure(EntityTypeBuilder<BankKycCopilot.Domain.Entities.Application> builder)
    {
        builder.ToTable("applications");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.ApplicantId)
            .IsRequired();

        builder.Property(x => x.ApplicationReference)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Channel)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(x => x.Status)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(x => x.SubmittedAt)
            .IsRequired();

        builder.Property(x => x.CreatedAt)
            .IsRequired();

        builder.Property(x => x.UpdatedAt);

        builder.Property(x => x.IsDeleted)
            .IsRequired();

        builder.HasIndex(x => x.ApplicationReference)
            .IsUnique();

        builder.HasIndex(x => x.ApplicantId);

        builder.HasOne<Applicant>()
            .WithMany()
            .HasForeignKey(x => x.ApplicantId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}