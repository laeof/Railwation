using Application.Dto;
using Application.Interface.Repository;
using Application.Mappers;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("[controller]")]
[ApiController]
public class CountryController: ControllerBase
{
    private readonly ICountryRepository countryRepository;

    public CountryController(ICountryRepository countryRepository)
    {
        this.countryRepository = countryRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var countriesResult = await countryRepository.GetCountriesAsync();

        if(countriesResult.IsFailure) return NotFound(countriesResult.Error);

        return Ok(countriesResult.Value);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetId(Guid id)
    {
        var countryResult = await countryRepository.GetCountryWithIdAsync(id);

        if (countryResult.IsFailure) return NotFound(countryResult.Error);

        return Ok(countryResult.Value);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CountryDto country)
    {
        var countryResult = await countryRepository.CreateCountryAsync(AutoMapper.CountryDtoMapper(country));

        if(countryResult.IsFailure) return BadRequest(countryResult.Error);

        return Ok(countryResult.Value);
    }
}
