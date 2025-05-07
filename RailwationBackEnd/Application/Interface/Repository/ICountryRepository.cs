using Application.Common;
using Domain.Entities;

namespace Application.Interface.Repository;

public interface ICountryRepository
{
    Task<Result<Country>> GetCountryWithIdAsync(Guid id);
    Task<Result<CountryConnection>> GetCountryConnectionsWithCountryIdAsync(Guid id);
    Task<Result<Country>> GetCountriesAsync();
    Task<Result<Country>> CreateCountryAsync(Country country);
    Task<Result<CountryConnection>> CreateCountryConnectionAsync(CountryConnection countryConnection);
}
