using Application.Common;
using Domain.Entities;

namespace Application.Interface.Repository;

public interface ICountryRepository
{
    Task<Result<List<Country>>> GetCountriesAsync();
    Task<Result<Country>> GetCountryWithIdAsync(Guid id);
    Task<Result<Country>> CreateCountryAsync(Country country);
    Task<Result<List<CountryConnection>>> GetCountryConnectionsWithCountryIdAsync(Guid id);
    Task<Result<List<CountryConnection>>> GetCountryConnectionsAsync();
    Task<Result<CountryConnection>> CreateCountryConnectionAsync(CountryConnection countryConnection);
}
