using BankKycCopilot.Domain.Common;
using BankKycCopilot.Domain.Enums;

namespace BankKycCopilot.Domain.Entities;

public class ReviewCase : BaseEntity
{
    public Guid ApplicationId { get; private set; }
    public RiskLevel RiskLevel { get; private set; }
    public int PriorityScore { get; private set; }
    public CaseStatus Status { get; private set; }
    public string? AssignedAnalyst { get; private set; }
    public DateTime OpenedAt { get; private set; }
    public DateTime? ClosedAt { get; private set; }

    private ReviewCase()
    {
    }

    public ReviewCase(Guid applicationId, RiskLevel riskLevel, int priorityScore)
    {
        ApplicationId = applicationId;
        RiskLevel = riskLevel;
        PriorityScore = priorityScore;
        Status = CaseStatus.Open;
        OpenedAt = DateTime.UtcNow;
    }

    public void AssignAnalyst(string analyst)
    {
        AssignedAnalyst = analyst;
        Status = CaseStatus.InReview;
        MarkAsUpdated();
    }

    public void CloseCase()
    {
        Status = CaseStatus.Closed;
        ClosedAt = DateTime.UtcNow;
        MarkAsUpdated();
    }

    public void UpdateRisk(RiskLevel riskLevel, int priorityScore)
    {
        RiskLevel = riskLevel;
        PriorityScore = priorityScore;
        MarkAsUpdated();
    }
}