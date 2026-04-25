using AutoMapper;
using BankKycCopilot.Application.DTOs;
using BankKycCopilot.Domain.Entities;

namespace BankKycCopilot.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Applicant, ApplicantDto>();
    }
}