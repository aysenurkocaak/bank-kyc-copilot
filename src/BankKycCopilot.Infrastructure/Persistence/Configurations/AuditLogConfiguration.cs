using BankKycCopilot.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankKycCopilot.Infrastructure.Persistence.Configurations;

public class AuditLogConfiguration : IEntityTypeConfiguration<AuditLog>
{
    public void Configure(EntityTypeBuilder<AuditLog> builder)
    {
        builder.ToTable("audit_logs");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.EntityType)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.EntityId)
            .IsRequired();

        builder.Property(x => x.Action)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Detail)
            .HasMaxLength(2000);

        builder.Property(x => x.PerformedBy)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(x => x.PerformedAt)
            .IsRequired();

        builder.Property(x => x.CreatedAt)
            .IsRequired();

        builder.Property(x => x.UpdatedAt);

        builder.Property(x => x.IsDeleted)
            .IsRequired();

        builder.HasIndex(x => x.EntityType);

        builder.HasIndex(x => x.EntityId);

        builder.HasIndex(x => x.PerformedAt);
    }
}
