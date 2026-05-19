namespace BankKycCopilot.Application.Interfaces.Workflows;

public interface IWorkflowClient
{
    Task NotifyApplicantCreatedAsync(Guid applicantId, CancellationToken cancellationToken = default);
}