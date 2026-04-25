using System.ComponentModel.DataAnnotations;

namespace BankKycCopilot.Application.DTOs;

public sealed class CreateApplicantDto
{
    [Required]
    [MaxLength(200)]
    public string FullName { get; init; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string NationalId { get; init; } = string.Empty;

    [Required]
    [MaxLength(30)]
    public string Phone { get; init; } = string.Empty;

    [Required]
    [EmailAddress]
    [MaxLength(150)]
    public string Email { get; init; } = string.Empty;

    [Required]
    public DateTime BirthDate { get; init; }

    [Required]
    [MaxLength(100)]
    public string Country { get; init; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string City { get; init; } = string.Empty;
}