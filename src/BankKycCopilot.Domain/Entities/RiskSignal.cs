using BankKycCopilot.Domain.Common;
using BankKycCopilot.Domain.Enums;
namespace BankKycCopilot.Domain.Entities;
public class RiskSignal : BaseEntity
{
    public Guid ApplicationId { get; private set; }
    public string SignalCode { get; private set; } = null!;
    public RiskSignalType SignalType { get; private set; }
    public RiskSeverity Severity { get; private set; }
    public string Description { get; private set; } = null!;
    public bool IsActive { get; private set; }
    public DateTime DetectedAt { get; private set; }
    private RiskSignal()
    {
    }

    public RiskSignal(
        Guid applicationId,
        string signalCode,
        RiskSignalType signalType,
        RiskSeverity severity,
        string description)
    {
        ApplicationId = applicationId;
        SignalCode = signalCode;
        SignalType = signalType;
        Severity = severity;
        Description = description;
        IsActive = true;
        DetectedAt = DateTime.UtcNow;
    }

    public void Deactivate()
    {
        IsActive = false;
        MarkAsUpdated();
    }
}