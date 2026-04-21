using BankKycCopilot.Domain.Common;

namespace BankKycCopilot.Domain.Entities;

public class AuditLog : BaseEntity
{
    public string EntityType { get; private set; } = null!;
    public Guid EntityId { get; private set; }
    public string Action { get; private set; } = null!;
    public string? Detail { get; private set; }
    public string PerformedBy { get; private set; } = null!;
    public DateTime PerformedAt { get; private set; }

    private AuditLog()
    {
    }

    public AuditLog(
        string entityType,
        Guid entityId,
        string action,
        string? detail,
        string performedBy)
    {
        EntityType = entityType;
        EntityId = entityId;
        Action = action;
        Detail = detail;
        PerformedBy = performedBy;
        PerformedAt = DateTime.UtcNow;
    }
}