using BankKycCopilot.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankKycCopilot.Infrastructure.Persistence.Configurations;

public class ReviewCaseConfiguration : IEntityTypeConfiguration<ReviewCase>
{
    public void Configure(EntityTypeBuilder<ReviewCase> builder)
    {
        builder.ToTable("review_cases");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.ApplicationId)
            .IsRequired();

        builder.Property(x => x.RiskLevel)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(x => x.PriorityScore)
            .IsRequired();

        builder.Property(x => x.Status)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(x => x.AssignedAnalyst)
            .HasMaxLength(150);

        builder.Property(x => x.OpenedAt)
            .IsRequired();

        builder.Property(x => x.ClosedAt);

        builder.Property(x => x.CreatedAt)
            .IsRequired();

        builder.Property(x => x.UpdatedAt);

        builder.Property(x => x.IsDeleted)
            .IsRequired();

        builder.HasIndex(x => x.ApplicationId)
            .IsUnique();

        builder.HasIndex(x => x.Status);

        builder.HasIndex(x => x.RiskLevel);

        builder.HasOne<BankKycCopilot.Domain.Entities.Application>()
            .WithOne()
            .HasForeignKey<ReviewCase>(x => x.ApplicationId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}