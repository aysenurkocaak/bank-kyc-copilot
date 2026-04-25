using BankKycCopilot.Application.Interfaces;
using BankKycCopilot.Domain.Entities;
using BankKycCopilot.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BankKycCopilot.Infrastructure.Repositories;

public class ApplicantRepository : IApplicantRepository
{
    private readonly AppDbContext _context;

    public ApplicantRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Applicant applicant, CancellationToken cancellationToken = default)
    {
        await _context.Applicants.AddAsync(applicant, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> ExistsByNationalIdAsync(string nationalId, CancellationToken cancellationToken = default)
    {
        return await _context.Applicants
        .AnyAsync(x => x.NationalId == nationalId, cancellationToken);
    }
    public async Task<List<Applicant>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Applicants
        .AsNoTracking()
        .ToListAsync(cancellationToken);
    }
}