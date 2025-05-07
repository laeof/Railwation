using Application.Dto;
using Domain.Entities;

namespace Application.Mappers;

public static class AutoMapper
{
    public static BorderCrossing BorderCrossDtoMapper(BorderCrossDto dto) => new() {
        CountryAId = dto.CountryAId,
        CountryBId = dto.CountryBId,
        HasRailway = dto.HasRailway,
    };

    public static CityConnection CityConnectDtoMapper(CityConnectionDto dto) => new()
    {
        FromCityId = dto.FromCityId,
        ToCityId = dto.ToCityId,
        FrequencyPerWeek = dto.FrequencyPerWeek,
        IsFreight = dto.IsFreight,
        IsPassenger = dto.IsPassenger,
    };

    public static CityCrossing CityCrossDtoMapper(CityCrossingDto dto) => new()
    {
        CityAId = dto.CityAId,
        CityBId = dto.CityBId,
        HasRailway = dto.HasRailway,
    };

    public static City CityDtoMapper(CityDto dto) => new()
    {
        CountryId = dto.CountryId,
        Name = dto.Name,
    };

    public static CountryConnection CountryConnectionDtoMapper(CountryConnectionDto dto) => new()
    {
        FromCountryId = dto.FromCountryId,
        HasFreightService = dto.HasFreightService,
        HasPassengerService = dto.HasPassengerService,
        LogisticsScore = dto.LogisticsScore,
        ToCountryId = dto.ToCountryId,
        WeeklyFrequency = dto.WeeklyFrequency,
    };

    public static Country CountryDtoMapper(CountryDto dto) => new()
    {
        Name = dto.Name,
    };
}
