using Application.Common;
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

        public Task<Result<List<City>>> CreateCityAsync(City city)
        {
            throw new NotImplementedException();
        }

        public Task<Result<CityConnection>> CreateCityConnectionAsync(CityConnection cityConnection)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<List<City>>> GetCitiesWithCountryIdAsync(Guid id)
        {
            var citiesResult = await context.Cities
                .Where(c => c.CountryId == id)
                .Include(c => c.CityConnections)
                .ToListAsync();

            if (citiesResult is null) return Result<List<City>>.Faillure(new("404", "Cities are not found"));

            return Result<List<City>>.Success(citiesResult);
        }

        public Task<Result<List<CityConnection>>> GetCityConnectionsWithCountryIdAsync(Guid countryId)
        {
            throw new NotImplementedException();
        }
    }
}
