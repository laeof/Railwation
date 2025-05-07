using Application.Dto;
using Application.Interface.Repository;
using Application.Mappers;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("[controller]")]
[ApiController]
public class ConnectionController: ControllerBase
{
    private readonly ICountryRepository countryRepository;
    private readonly ICityRepository cityRepository;
    public ConnectionController(ICountryRepository countryRepository,
        ICityRepository cityRepository)
    {
        this.countryRepository = countryRepository;
        this.cityRepository = cityRepository;
    }
    [HttpGet("city/by-country/{countryId}")]
    public async Task<IActionResult> GetCityConnectionsByCountry(Guid countryId)
    {
        var connectionsResult = await cityRepository.GetCityConnectionsWithCountryIdAsync(countryId);

        if (connectionsResult.IsFailure) return NotFound(connectionsResult.Error);

        return Ok(connectionsResult.Value);
    }

    [HttpPost("city/create")]
    public async Task<IActionResult> CreateCityConnection([FromBody] CityConnectionDto connection)
    {
        var connectionResult = 
            await cityRepository.CreateCityConnectionAsync(AutoMapper.CityConnectDtoMapper(connection));

        if (connectionResult.IsFailure) return NotFound(connectionResult.Error);

        return Ok(connection);
    }

    [HttpGet("country/by-country/{countryId}")]
    public async Task<IActionResult> GetCountryConnectionsByCountry(Guid countryId)
    {
        var connectionsResult = await countryRepository.GetCountryConnectionsWithCountryIdAsync(countryId);

        if (connectionsResult.IsFailure) return NotFound(connectionsResult.Error);

        return Ok(connectionsResult.Value);
    }

    [HttpPost("country/create")]
    public async Task<IActionResult> CreateCountryConnection([FromBody] CountryConnectionDto connection)
    {
        var connectionResult = 
            await countryRepository.CreateCountryConnectionAsync(AutoMapper.CountryConnectionDtoMapper(connection));

        if (connectionResult.IsFailure) return NotFound(connectionResult.Error);

        return Ok(connection);
    }
}
