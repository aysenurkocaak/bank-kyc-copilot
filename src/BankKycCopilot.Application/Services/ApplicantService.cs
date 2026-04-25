using BankKycCopilot.Application.DTOs;
using BankKycCopilot.Application.Interfaces;
using BankKycCopilot.Domain.Entities;

namespace BankKycCopilot.Application.Services;

public class ApplicantService
{
    private readonly IApplicantRepository _repository;

    public ApplicantService(IApplicantRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> CreateAsync(CreateApplicantDto dto, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(dto.FullName))
            throw new ArgumentException("Full name is required.");

        if (string.IsNullOrWhiteSpace(dto.NationalId))
            throw new ArgumentException("National id is required.");

        var exists = await _repository.ExistsByNationalIdAsync(dto.NationalId, cancellationToken);

        if (exists)
            throw new Exception("Bu NationalId ile kayıt zaten var");

        var applicant = new Applicant(
            dto.FullName.Trim(),
            dto.NationalId.Trim(),
            dto.Phone.Trim(),
            dto.Email.Trim(),
            dto.BirthDate,
            dto.Country.Trim(),
            dto.City.Trim()
        );

        await _repository.AddAsync(applicant, cancellationToken);

        return applicant.Id;
    }
    public async Task<List<Applicant>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _repository.GetAllAsync(cancellationToken);
    }
}