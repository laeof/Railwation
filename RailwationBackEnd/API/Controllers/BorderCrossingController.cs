using Application.Dto;
using Application.Interface.Repository;
using Application.Mappers;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("[controller]")]
[ApiController]
public class BorderCrossingController : ControllerBase
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

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var borderCrossingsResult = await borderCrossingRepository.GetBorderCrossingsAsync();

        if (borderCrossingsResult.IsFailure) return NotFound(borderCrossingsResult.Error);

        return Ok(borderCrossingsResult.Value);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] BorderCrossDto crossing)
    {
        var borderCrossingsResult =
            await borderCrossingRepository.CreateBorderCrossingAsync(AutoMapper.BorderCrossDtoMapper(crossing));

        if (borderCrossingsResult.IsFailure) return BadRequest(borderCrossingsResult.Error);

        return Ok(crossing);
    }
}
