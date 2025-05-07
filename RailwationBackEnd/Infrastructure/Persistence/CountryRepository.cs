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

    public Task<Result<Country>> CreateCountryAsync(Country country)
    {
        throw new NotImplementedException();
    }

    public Task<Result<CountryConnection>> CreateCountryConnectionAsync(CountryConnection countryConnection)
    {
        throw new NotImplementedException();
    }

    public Task<Result<Country>> GetCountriesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Result<CountryConnection>> GetCountryConnectionsWithCountryIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<Country>> GetCountryWithIdAsync(Guid id)
    {
        var countryResult = await context.Countries
            .Include(c => c.CountryConnections)
            .Include(c => c.BorderCrossings)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (countryResult is null) return Result<Country>.Faillure(new("404", "Country is not found"));

        return Result<Country>.Success(countryResult);
    }
}
