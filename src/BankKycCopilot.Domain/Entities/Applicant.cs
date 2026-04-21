using BankKycCopilot.Domain.Common;
namespace BankKycCopilot.Domain.Entities;
public class Applicant : BaseEntity
{
    public string FullName { get; private set; } = null!;
    public string NationalId { get; private set; } = null!;
    public string Phone { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    public DateTime BirthDate { get; private set; }
    public string Country { get; private set; } = null!;
    public string City { get; private set; } = null!;
    private Applicant()
    {
    }

    public Applicant(
        string fullName,
        string nationalId,
        string phone,
        string email,
        DateTime birthDate,
        string country,
        string city)
    {
        FullName = fullName;
        NationalId = nationalId;
        Phone = phone;
        Email = email;
        BirthDate = birthDate;
        Country = country;
        City = city;
    }

    public void UpdateContactInfo(string phone, string email, string country, string city)
    {
        Phone = phone;
        Email = email;
        Country = country;
        City = city;

        MarkAsUpdated();
    }
}