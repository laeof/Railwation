using Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("[controller]")]
[ApiController]
public class IntegrationScoreController: ControllerBase
{
    private readonly CalculateIntegrationScoreUseCase calculateIntegrationScoreUseCase;

    public IntegrationScoreController(CalculateIntegrationScoreUseCase calculateIntegrationScoreUseCase)
    {
        this.calculateIntegrationScoreUseCase = calculateIntegrationScoreUseCase;
    }

    [HttpGet("{countryId}")]
    public async Task<IActionResult> GetScore(Guid countryId)
    {
        var scoreResult = await calculateIntegrationScoreUseCase.ExecuteAsync(countryId);

        if (scoreResult.IsFailure) return BadRequest(scoreResult.Error);

        return Ok(new { countryId, scoreResult.Value });
    }
}
