namespace BankKycCopilot.Application.DTOs;

public sealed class CreateApplicantDto
{
    public string FullName { get; init; } = string.Empty;
    public string NationalId { get; init; } = string.Empty;
    public string Phone { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public DateTime BirthDate { get; init; }
    public string Country { get; init; } = string.Empty;
    public string City { get; init; } = string.Empty;
}