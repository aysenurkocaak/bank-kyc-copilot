namespace BankKycCopilot.Application.DTOs;

public class ApplicantDto
{
    public Guid Id { get; set; }

    public string FullName { get; set; } = string.Empty;

    public string NationalId { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Country { get; set; } = string.Empty;

    public string City { get; set; } = string.Empty;
}