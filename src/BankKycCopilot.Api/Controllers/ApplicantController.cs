using BankKycCopilot.Application.DTOs;
using BankKycCopilot.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace BankKycCopilot.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ApplicantController : ControllerBase
{
    private readonly ApplicantService _service;

    public ApplicantController(ApplicantService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateApplicantDto dto,
        CancellationToken cancellationToken)
    {
        var id = await _service.CreateAsync(dto, cancellationToken);
        return Ok(id);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var result = await _service.GetAllAsync(cancellationToken);
        return Ok(result);
    }
}