namespace BankKycCopilot.Infrastructure.Configurations;

public class WorkflowOptions
{
    public const string SectionName = "Workflow";

    public string BaseUrl { get; set; } = string.Empty;

    public string ApplicantCreatedEndpoint { get; set; } = string.Empty;
}