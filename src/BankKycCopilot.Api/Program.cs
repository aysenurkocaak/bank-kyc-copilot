using BankKycCopilot.Application.Interfaces;
using BankKycCopilot.Application.Services;
using BankKycCopilot.Infrastructure.Persistence;
using BankKycCopilot.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using BankKycCopilot.Application.Mapping;
using BankKycCopilot.Api.Middlewares;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.AspNetCore;
using BankKycCopilot.Application.Validators;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IApplicantRepository, ApplicantRepository>();
builder.Services.AddScoped<ApplicantService>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<CreateApplicantDtoValidator>();

builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.InvalidModelStateResponseFactory = context =>
        {
            var errors = context.ModelState
                .Where(x => x.Value?.Errors.Count > 0)
                .ToDictionary(
                    x => x.Key,
                    x => x.Value!.Errors.Select(e => e.ErrorMessage).ToArray()
                );

            return new BadRequestObjectResult(new
            {
                message = "Validation failed.",
                errors
            });
        };
    });
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();


app.Run();