using Application.Common;
using Domain.Entities;

namespace Application.Interface.Repository;

public interface ICityRepository
{
    Task<Result<List<City>>> GetCitiesWithCountryIdAsync(Guid id);
    Task<Result<List<CityConnection>>> GetCityConnectionsWithCountryIdAsync(Guid countryId);
    Task<Result<CityConnection>> CreateCityConnectionAsync(CityConnection cityConnection);
    Task<Result<List<City>>> CreateCityAsync(City city);
    
}
