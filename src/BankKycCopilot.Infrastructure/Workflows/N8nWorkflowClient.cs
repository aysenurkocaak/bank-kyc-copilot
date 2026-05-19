using System.Net.Http.Json;
using BankKycCopilot.Application.Interfaces.Workflows;
using BankKycCopilot.Infrastructure.Configurations;
using Microsoft.Extensions.Options;

namespace BankKycCopilot.Infrastructure.Workflows;

public class N8nWorkflowClient : IWorkflowClient
{
    private readonly HttpClient _httpClient;
    private readonly WorkflowOptions _options;

    public N8nWorkflowClient(
        HttpClient httpClient,
        IOptions<WorkflowOptions> options)
    {
        _httpClient = httpClient;
        _options = options.Value;
    }

    public async Task NotifyApplicantCreatedAsync(Guid applicantId, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(_options.BaseUrl))
            return;

        if (string.IsNullOrWhiteSpace(_options.ApplicantCreatedEndpoint))
            return;

        _httpClient.BaseAddress = new Uri(_options.BaseUrl);

        var payload = new
        {
            applicantId,
            eventType = "ApplicantCreated",
            occurredAt = DateTime.UtcNow
        };

        var response = await _httpClient.PostAsJsonAsync(
            _options.ApplicantCreatedEndpoint,
            payload,
            cancellationToken);

        response.EnsureSuccessStatusCode();
    }
}