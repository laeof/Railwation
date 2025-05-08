using Application.Common;
using Application.Dto;
using Application.Interface.Repository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class CityRepository : ICityRepository
    {
        private readonly AppDbContext context;
        public CityRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<Result<City>> CreateCityAsync(City city)
        {
            try
            {
                context.Entry(city).State = EntityState.Added;
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return Result<City>.Faillure(new("500", ex.Message));
            }

            return Result<City>.Success(city);
        }

        public async Task<Result<CityConnection>> CreateCityConnectionAsync(CityConnection cityConnection)
        {
            try
            {
                context.Entry(cityConnection).State = EntityState.Added;
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return Result<CityConnection>.Faillure(new("500", ex.Message));
            }

            return Result<CityConnection>.Success(cityConnection);
        }

        public async Task<Result<List<City>>> GetCitiesWithCountryIdAsync(Guid id)
        {
            var citiesResult = await context.Cities
                .Where(c => c.CountryId == id)
                .Select(c => new City
                {
                    Id = c.Id,
                    Name = c.Name,
                    CountryId = c.CountryId,
                    Country = new Country
                    {
                        Name = c.Country.Name
                    },
                    FromCityConnections = c.FromCityConnections
                    .Select(c => new CityConnection
                    {
                        Id = c.Id,
                        FromCityId = c.FromCityId,
                        FrequencyPerWeek = c.FrequencyPerWeek,
                        IsFreight = c.IsFreight,
                        ToCityId = c.ToCityId,
                        FromCity = new City
                        {
                            Id = c.FromCity.Id,
                            Name = c.FromCity.Name,
                            CountryId = c.FromCity.CountryId,
                            Country = new Country
                            {
                                Name = c.FromCity.Country.Name
                            }
                        },
                        ToCity = new City
                        {
                            Id = c.ToCity.Id,
                            Name = c.ToCity.Name,
                            CountryId = c.ToCity.CountryId,
                            Country = new Country
                            {
                                Name = c.FromCity.Country.Name
                            }
                        }
                    }).ToList(),
                    ToCityConnections = c.ToCityConnections
                    .Select(c => new CityConnection
                    {
                        Id = c.Id,
                        FromCityId = c.FromCityId,
                        FrequencyPerWeek = c.FrequencyPerWeek,
                        IsFreight = c.IsFreight,
                        ToCityId = c.ToCityId,
                        FromCity = new City
                        {
                            Id = c.FromCity.Id,
                            Name = c.FromCity.Name,
                            CountryId = c.FromCity.CountryId,
                            Country = new Country
                            {
                                Name = c.FromCity.Country.Name
                            }
                        },
                        ToCity = new City
                        {
                            Id = c.ToCity.Id,
                            Name = c.ToCity.Name,
                            CountryId = c.ToCity.CountryId,
                            Country = new Country
                            {
                                Name = c.FromCity.Country.Name
                            }
                        }
                    }).ToList(),

                })
                .ToListAsync();

            if (citiesResult is null) return Result<List<City>>.Faillure(new("404", "Cities are not found"));

            return Result<List<City>>.Success(citiesResult);
        }

        public async Task<Result<List<CityConnection>>> GetCityConnectionsWithCountryIdAsync(Guid countryId)
        {
            var cityConnectionsResult = await context.CityConnections
                .Where(c => c.FromCity.CountryId == countryId || c.ToCity.CountryId == countryId)
                .Select(c => new CityConnection
                {
                    Id = c.Id,
                    FromCityId = c.FromCityId,
                    FrequencyPerWeek = c.FrequencyPerWeek,
                    IsFreight = c.IsFreight,
                    ToCityId = c.ToCityId,
                    FromCity = new City
                    {
                        Id = c.FromCity.Id,
                        Name = c.FromCity.Name,
                        CountryId = c.FromCity.CountryId,
                        Country = new Country
                        {
                            Name = c.FromCity.Country.Name
                        }
                    },
                    ToCity = new City
                    {
                        Id = c.ToCity.Id,
                        Name = c.ToCity.Name,
                        CountryId = c.ToCity.CountryId,
                        Country = new Country
                        {
                            Name = c.FromCity.Country.Name
                        }
                    }
                })
                .ToListAsync();

            if (cityConnectionsResult is null) return Result<List<CityConnection>>.Faillure(new("404", "Cities are not found"));

            return Result<List<CityConnection>>.Success(cityConnectionsResult);
        }
    }
}
