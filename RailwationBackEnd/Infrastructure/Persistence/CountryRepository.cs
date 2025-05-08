using Application.Common;
using Application.Interface.Repository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class CountryRepository : ICountryRepository
{
    private readonly AppDbContext context;
    public CountryRepository(AppDbContext context)
    {
        this.context = context;
    }

    public async Task<Result<Country>> CreateCountryAsync(Country country)
    {
        try
        {
            context.Entry(country).State = EntityState.Added;
            await context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return Result<Country>.Faillure(new("500", ex.Message));
        }

        return Result<Country>.Success(country);
    }

    public async Task<Result<CountryConnection>> CreateCountryConnectionAsync(CountryConnection countryConnection)
    {
        try
        {
            context.Entry(countryConnection).State = EntityState.Added;
            await context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return Result<CountryConnection>.Faillure(new("500", ex.Message));
        }

        return Result<CountryConnection>.Success(countryConnection);
    }

    public async Task<Result<List<Country>>> GetCountriesAsync()
    {
        var countriesResult = await context.Countries
            .Select(c => new Country
            {
                Id = c.Id,
                Name = c.Name,
                BorderCrossingsAsA = c.BorderCrossingsAsA
                    .Select(b => new BorderCrossing
                    {
                        Id = b.Id,
                        CountryAId = b.CountryAId,
                        CountryBId = b.CountryBId,
                        CountryA = new Country { Name = b.CountryA.Name },
                        CountryB = new Country { Name = b.CountryB.Name },
                    })
                    .ToList(),
                BorderCrossingsAsB = c.BorderCrossingsAsB
                    .Select(b => new BorderCrossing
                    {
                        Id = b.Id,
                        CountryAId = b.CountryAId,
                        CountryBId = b.CountryBId,
                        CountryA = new Country { Name = b.CountryA.Name },
                        CountryB = new Country { Name = b.CountryB.Name },
                    })
                    .ToList(),
                FromCountryConnections = c.FromCountryConnections
                    .Select(b => new CountryConnection
                    {
                        Id = b.Id,
                        FromCountryId = b.FromCountryId,
                        ToCountryId = b.ToCountryId,
                        FromCountry = new Country { Name = b.FromCountry.Name },
                        ToCountry = new Country { Name = b.ToCountry.Name },
                        HasFreightService = b.HasFreightService,
                        HasPassengerService = b.HasPassengerService,
                        LogisticsScore = b.LogisticsScore,
                        WeeklyFrequency = b.WeeklyFrequency,
                    })
                    .ToList(),
                ToCountryConnections = c.ToCountryConnections
                    .Select(b => new CountryConnection
                    {
                        Id = b.Id,
                        FromCountryId = b.FromCountryId,
                        ToCountryId = b.ToCountryId,
                        FromCountry = new Country { Name = b.FromCountry.Name },
                        ToCountry = new Country { Name = b.ToCountry.Name },
                        HasFreightService = b.HasFreightService,
                        HasPassengerService = b.HasPassengerService,
                        LogisticsScore = b.LogisticsScore,
                        WeeklyFrequency = b.WeeklyFrequency,
                    })
                    .ToList()
            })
           .ToListAsync();

        if (countriesResult is null) return Result<List<Country>>.Faillure(new("404", "Countries are not found"));

        return Result<List<Country>>.Success(countriesResult);
    }

    public async Task<Result<List<CountryConnection>>> GetCountryConnectionsWithCountryIdAsync(Guid id)
    {
        var connectionsResult = await context.CountryConnections
            .Where(r => r.FromCountryId == id)
            .Select(c => new CountryConnection
            {
                Id = id,
                LogisticsScore = c.LogisticsScore,
                FromCountryId = c.FromCountryId,
                HasFreightService = c.HasFreightService,
                HasPassengerService = c.HasPassengerService,
                ToCountryId = c.ToCountryId,
                WeeklyFrequency = c.WeeklyFrequency,
                ToCountry = new Country { Name = c.ToCountry.Name },
                FromCountry = new Country { Name = c.FromCountry.Name },
            })
            .ToListAsync();

        if (connectionsResult is null) return Result<List<CountryConnection>>.Faillure(new("404", "Countries are not found"));

        return Result<List<CountryConnection>>.Success(connectionsResult);
    }

    public async Task<Result<Country>> GetCountryWithIdAsync(Guid id)
    {
        var countryResult = await context.Countries
            .Where(c => c.Id == id)
            .Select(c => new Country { 
                Id = c.Id,
                Name = c.Name,
                BorderCrossingsAsA = c.BorderCrossingsAsA
                    .Select(b => new BorderCrossing
                    {
                        Id = b.Id,
                        CountryAId = b.CountryAId,
                        CountryBId = b.CountryBId,
                        CountryA = new Country { Name = b.CountryA.Name },
                        CountryB = new Country { Name = b.CountryB.Name },
                        HasRailway = b.HasRailway
                    })
                    .ToList(),
                BorderCrossingsAsB = c.BorderCrossingsAsB
                    .Select(b => new BorderCrossing
                    {
                        Id = b.Id,
                        CountryAId = b.CountryAId,
                        CountryBId = b.CountryBId,
                        CountryA = new Country { Name = b.CountryA.Name },
                        CountryB = new Country { Name = b.CountryB.Name },
                        HasRailway = b.HasRailway
                    })
                    .ToList(),
                FromCountryConnections = c.FromCountryConnections
                    .Select(b => new CountryConnection
                    {
                        Id = b.Id,
                        FromCountryId = b.FromCountryId,
                        ToCountryId = b.ToCountryId,
                        FromCountry = new Country { Name = b.FromCountry.Name },
                        ToCountry = new Country { Name = b.ToCountry.Name },
                        HasFreightService = b.HasFreightService,
                        HasPassengerService = b.HasPassengerService,
                        LogisticsScore = b.LogisticsScore,
                        WeeklyFrequency = b.WeeklyFrequency,
                    })
                    .ToList(),
                ToCountryConnections = c.ToCountryConnections
                    .Select(b => new CountryConnection
                    {
                        Id = b.Id,
                        FromCountryId = b.FromCountryId,
                        ToCountryId = b.ToCountryId,
                        FromCountry = new Country { Name = b.FromCountry.Name },
                        ToCountry = new Country { Name = b.ToCountry.Name },
                        HasFreightService = b.HasFreightService,
                        HasPassengerService = b.HasPassengerService,
                        LogisticsScore = b.LogisticsScore,
                        WeeklyFrequency = b.WeeklyFrequency,
                    })
                    .ToList()
            })
            .FirstOrDefaultAsync();

        if (countryResult is null) return Result<Country>.Faillure(new("404", "Country is not found"));

        return Result<Country>.Success(countryResult);
    }
}
