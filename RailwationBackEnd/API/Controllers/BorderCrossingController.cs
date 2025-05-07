using Application.Interface.Repository;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("[contrtoller]")]
[ApiController]
public class BorderCrossingController: ControllerBase
{
    private readonly IBorderCrossingRepository borderCrossingRepository;
    public BorderCrossingController(IBorderCrossingRepository borderCrossingRepository)
    {
        this.borderCrossingRepository = borderCrossingRepository;
    }

    [HttpGet("by-country/{countryId}")]
    public async Task<IActionResult> GetByCountry(Guid countryId)
    {
        var borderCrossingsResult = await borderCrossingRepository.GetBorderCrossingsWithCountryIdAsync(countryId);

        if (borderCrossingsResult.IsFailure) return NotFound(borderCrossingsResult.Error);

        return Ok(borderCrossingsResult.Value);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] BorderCrossing crossing)
    {
        var borderCrossingsResult = await borderCrossingRepository.CreateBorderCrossingAsync(crossing);

        if (borderCrossingsResult.IsFailure) return NotFound(borderCrossingsResult.Error);

        return Ok(crossing);
    }
}
