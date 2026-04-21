using BankKycCopilot.Domain.Common;
using BankKycCopilot.Domain.Enums;

namespace BankKycCopilot.Domain.Entities;

public class Recommendation : BaseEntity
{
    public Guid CaseId { get; private set; }
    public RecommendationAction Action { get; private set; }
    public string Explanation { get; private set; } = null!;
    public DateTime GeneratedAt { get; private set; }
    public bool IsApplied { get; private set; }
    private Recommendation()
    {
    }

    public Recommendation(Guid caseId, RecommendationAction action, string explanation)
    {
        CaseId = caseId;
        Action = action;
        Explanation = explanation;
        GeneratedAt = DateTime.UtcNow;
        IsApplied = false;
    }

    public void MarkAsApplied()
    {
        IsApplied = true;
        MarkAsUpdated();
    }

    public void UpdateExplanation(string explanation)
    {
        Explanation = explanation;
        MarkAsUpdated();
    }
}