﻿using Application.Dto;
using Application.Interface.Repository;
using Application.Mappers;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("[controller]")]
[ApiController]
public class CityController: ControllerBase
{
    private readonly ICityRepository cityRepository;
    public CityController(ICityRepository cityRepository)
    {
        this.cityRepository = cityRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetByCountry()
    {
        var citiesResult = await cityRepository.GetAllCities();

        if (citiesResult.IsFailure) return NotFound(citiesResult.Error);

        return Ok(citiesResult.Value);
    }

    [HttpGet("by-country/{countryId}")]
    public async Task<IActionResult> GetByCountry(Guid countryId)
    {
        var citiesResult = await cityRepository.GetCitiesWithCountryIdAsync(countryId);

        if(citiesResult.IsFailure) return NotFound(citiesResult.Error);

        return Ok(citiesResult.Value);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CityDto city)
    {
        var cityResult = await cityRepository.CreateCityAsync(AutoMapper.CityDtoMapper(city));

        if (cityResult.IsFailure) return BadRequest(cityResult.Error);

        return Ok(cityResult.Value);
    }
}
