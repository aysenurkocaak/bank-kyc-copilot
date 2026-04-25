using BankKycCopilot.Application.DTOs;
using BankKycCopilot.Domain.Entities;

namespace BankKycCopilot.Application.Services;

public class ApplicantService
{
    public Applicant CreateApplicant(CreateApplicantDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.FullName))
            throw new ArgumentException("Full name is required.");

        if (string.IsNullOrWhiteSpace(dto.NationalId))
            throw new ArgumentException("National id is required.");

        if (string.IsNullOrWhiteSpace(dto.Phone))
            throw new ArgumentException("Phone is required.");

        if (string.IsNullOrWhiteSpace(dto.Email))
            throw new ArgumentException("Email is required.");

        if (string.IsNullOrWhiteSpace(dto.Country))
            throw new ArgumentException("Country is required.");

        if (string.IsNullOrWhiteSpace(dto.City))
            throw new ArgumentException("City is required.");

        return new Applicant(
            dto.FullName.Trim(),
            dto.NationalId.Trim(),
            dto.Phone.Trim(),
            dto.Email.Trim(),
            dto.BirthDate,
            dto.Country.Trim(),
            dto.City.Trim()
        );
    }
}