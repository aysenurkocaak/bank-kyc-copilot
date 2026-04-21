using BankKycCopilot.Domain.Common;
using BankKycCopilot.Domain.Enums;
namespace BankKycCopilot.Domain.Entities;
public class Application : BaseEntity
{
    public Guid ApplicantId { get; private set; }
    public string ApplicationReference { get; private set; } = null!;
    public ApplicationChannel Channel { get; private set; }
    public ApplicationStatus Status { get; private set; }
    public DateTime SubmittedAt { get; private set; }
    private Application()
    {
    }

    public Application(
        Guid applicantId,
        string applicationReference,
        ApplicationChannel channel)
    {
        ApplicantId = applicantId;
        ApplicationReference = applicationReference;
        Channel = channel;
        Status = ApplicationStatus.Pending;
        SubmittedAt = DateTime.UtcNow;
    }

    public void MarkInReview()
    {
        Status = ApplicationStatus.InReview;
        MarkAsUpdated();
    }

    public void Approve()
    {
        Status = ApplicationStatus.Approved;
        MarkAsUpdated();
    }

    public void Reject()
    {
        Status = ApplicationStatus.Rejected;
        MarkAsUpdated();
    }
}