using Application.Interface.Repository;
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
    public async Task<IActionResult> CreateCityConnection([FromBody] CityConnection connection)
    {
        var connectionResult = await cityRepository.CreateCityConnectionAsync(connection);

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
    public async Task<IActionResult> CreateCountryConnection([FromBody] CountryConnection connection)
    {
        var connectionResult = await countryRepository.CreateCountryConnectionAsync(connection);

        if (connectionResult.IsFailure) return NotFound(connectionResult.Error);

        return Ok(connection);
    }
}
