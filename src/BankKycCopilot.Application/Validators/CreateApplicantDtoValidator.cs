using BankKycCopilot.Application.DTOs;
using FluentValidation;

namespace BankKycCopilot.Application.Validators;

public class CreateApplicantDtoValidator : AbstractValidator<CreateApplicantDto>
{
    public CreateApplicantDtoValidator()
    {
        RuleFor(x => x.FullName)
            .NotEmpty().WithMessage("Full name boş olmamalı.")
            .MaximumLength(200).WithMessage("Full name en fazla 200 karakter olabilir.");

        RuleFor(x => x.NationalId)
            .NotEmpty().WithMessage("National id boş olmamalı.")
            .MaximumLength(50).WithMessage("National id en fazla 50 karakter olabilir.");

        RuleFor(x => x.Phone)
            .NotEmpty().WithMessage("Phone boş olmamalı.")
            .MaximumLength(30).WithMessage("Phone en fazla 30 karakter olabilir.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email boş olmamalı.")
            .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.")
            .MaximumLength(150).WithMessage("Email en fazla 150 karakter olabilir.");

        RuleFor(x => x.BirthDate)
            .NotEmpty().WithMessage("Birth date boş olmamalı.");

        RuleFor(x => x.Country)
            .NotEmpty().WithMessage("Country boş olmamalı.")
            .MaximumLength(100).WithMessage("Country en fazla 100 karakter olabilir.");

        RuleFor(x => x.City)
            .NotEmpty().WithMessage("City boş olmamalı.")
            .MaximumLength(100).WithMessage("City en fazla 100 karakter olabilir.");
    }
}