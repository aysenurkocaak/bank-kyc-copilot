using BankKycCopilot.Domain.Entities;

namespace BankKycCopilot.Application.Interfaces;

public interface IApplicantRepository
{
    Task AddAsync(Applicant applicant, CancellationToken cancellationToken = default);

    Task<bool> ExistsByNationalIdAsync(string nationalId, CancellationToken cancellationToken = default);
}