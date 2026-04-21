using BankKycCopilot.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ApplicationEntity = BankKycCopilot.Domain.Entities.Application;
namespace BankKycCopilot.Infrastructure.Persistence.Configurations;

public class RiskSignalConfiguration : IEntityTypeConfiguration<RiskSignal>
{
    public void Configure(EntityTypeBuilder<RiskSignal> builder)
    {
        builder.ToTable("risk_signals");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.ApplicationId)
            .IsRequired();

        builder.Property(x => x.SignalCode)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.SignalType)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(x => x.Severity)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(x => x.IsActive)
            .IsRequired();

        builder.Property(x => x.DetectedAt)
            .IsRequired();

        builder.Property(x => x.CreatedAt)
            .IsRequired();

        builder.Property(x => x.UpdatedAt);

        builder.Property(x => x.IsDeleted)
            .IsRequired();

        builder.HasIndex(x => x.ApplicationId);

        builder.HasIndex(x => x.SignalCode);

        builder.HasOne<ApplicationEntity>()
            .WithMany()
            .HasForeignKey(x => x.ApplicationId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}