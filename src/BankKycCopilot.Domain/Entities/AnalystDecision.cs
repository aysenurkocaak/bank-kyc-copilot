using BankKycCopilot.Domain.Common;
using BankKycCopilot.Domain.Enums;

namespace BankKycCopilot.Domain.Entities;

public class AnalystDecision : BaseEntity
{
    public Guid CaseId { get; private set; }
    public Guid RecommendationId { get; private set; }
    public AnalystDecisionType Decision { get; private set; }
    public string? DecisionNote { get; private set; }
    public DateTime DecidedAt { get; private set; }
    public bool IsOverride { get; private set; }

    private AnalystDecision()
    {
    }

    public AnalystDecision(
        Guid caseId,
        Guid recommendationId,
        AnalystDecisionType decision,
        string? decisionNote,
        bool isOverride)
    {
        CaseId = caseId;
        RecommendationId = recommendationId;
        Decision = decision;
        DecisionNote = decisionNote;
        DecidedAt = DateTime.UtcNow;
        IsOverride = isOverride;
    }
}