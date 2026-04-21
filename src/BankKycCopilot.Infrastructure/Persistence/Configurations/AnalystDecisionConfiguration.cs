using BankKycCopilot.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankKycCopilot.Infrastructure.Persistence.Configurations;

public class AnalystDecisionConfiguration : IEntityTypeConfiguration<AnalystDecision>
{
    public void Configure(EntityTypeBuilder<AnalystDecision> builder)
    {
        builder.ToTable("analyst_decisions");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.CaseId)
            .IsRequired();

        builder.Property(x => x.RecommendationId)
            .IsRequired();

        builder.Property(x => x.Decision)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(x => x.DecisionNote)
            .HasMaxLength(1000);

        builder.Property(x => x.DecidedAt)
            .IsRequired();

        builder.Property(x => x.IsOverride)
            .IsRequired();

        builder.Property(x => x.CreatedAt)
            .IsRequired();

        builder.Property(x => x.UpdatedAt);

        builder.Property(x => x.IsDeleted)
            .IsRequired();

        builder.HasIndex(x => x.CaseId)
            .IsUnique();

        builder.HasIndex(x => x.RecommendationId)
            .IsUnique();

        builder.HasOne<ReviewCase>()
            .WithOne()
            .HasForeignKey<AnalystDecision>(x => x.CaseId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne<Recommendation>()
            .WithOne()
            .HasForeignKey<AnalystDecision>(x => x.RecommendationId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}