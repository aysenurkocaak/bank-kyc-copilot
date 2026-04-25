using BankKycCopilot.Application.Interfaces;
using BankKycCopilot.Application.Services;
using BankKycCopilot.Infrastructure.Persistence;
using BankKycCopilot.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using BankKycCopilot.Application.Mapping;
using BankKycCopilot.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IApplicantRepository, ApplicantRepository>();
builder.Services.AddScoped<ApplicantService>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddControllers();
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