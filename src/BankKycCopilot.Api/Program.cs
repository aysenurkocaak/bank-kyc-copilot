using BankKycCopilot.Infrastructure.Configurations;
using BankKycCopilot.Application.Interfaces.Workflows;
using BankKycCopilot.Infrastructure.Workflows;
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
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IApplicantRepository, ApplicantRepository>();
builder.Services.AddScoped<ApplicantService>();
builder.Services.Configure<WorkflowOptions>(
    builder.Configuration.GetSection(WorkflowOptions.SectionName));
builder.Services.AddHttpClient<IWorkflowClient, N8nWorkflowClient>();
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
app.UseSerilogRequestLogging(options =>
{
    options.MessageTemplate =
        "HTTP {RequestMethod} {RequestPath} responded {StatusCode} in {Elapsed:0.0000} ms";
});

app.UseMiddleware<CorrelationIdMiddleware>();

app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

app.MapControllers();

app.Run();