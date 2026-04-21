using BankKycCopilot.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankKycCopilot.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public DbSet<Applicant> Applicants => Set<Applicant>();

    public DbSet<BankKycCopilot.Domain.Entities.Application> Applications => Set<BankKycCopilot.Domain.Entities.Application>();

    public DbSet<RiskSignal> RiskSignals => Set<RiskSignal>();

    public DbSet<ReviewCase> ReviewCases => Set<ReviewCase>();

    public DbSet<Recommendation> Recommendations => Set<Recommendation>();

    public DbSet<AnalystDecision> AnalystDecisions => Set<AnalystDecision>();

    public DbSet<AuditLog> AuditLogs => Set<AuditLog>();

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}